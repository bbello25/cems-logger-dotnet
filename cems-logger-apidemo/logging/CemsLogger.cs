using cems_logger_dotnet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using cems_logger_dotnet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace cems_logger_apidemo.logging
{
    public class CemsLogger : ILogger
    {
        private static object _lock = new Object();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;


        private CemsLoggerSender CemsLoggerSender { get; set; }

        public CemsLogger(IHttpContextAccessor httpContextAccessor, IConfiguration configuration,
            IHostingEnvironment env)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _env = env;
            var authenticationSection = _configuration.GetSection("Authentication");

            CemsLoggerSender = new CemsLoggerSender(authenticationSection["CemsApiKey"]);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Error;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (_lock)
            {
                var logEvent = new CemsLogEvent();
                var httpContext = _httpContextAccessor.HttpContext;

                logEvent.DotnetApplicationInfo.Name = _env.ApplicationName;
                logEvent.DotnetApplicationInfo.Host = _configuration["HostListen"];
                logEvent.DotnetApplicationInfo.Port = _configuration["PortListen"];
                logEvent.DotnetApplicationInfo.HostName = Environment.MachineName;
                logEvent.DotnetApplicationInfo.Os = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
                logEvent.DotnetApplicationInfo.Environment = _env.EnvironmentName;
                logEvent.DotnetApplicationInfo.AssemblyVersion = Assembly.GetEntryAssembly()
                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

                logEvent.AppendExceptionDetails(exception);
                logEvent.AddHttpContext(httpContext);
             
                CemsLoggerSender.SendLog(logEvent);
            }
        }
     
    }
}