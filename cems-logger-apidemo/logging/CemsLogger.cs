using cems_logger_dotnet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace cems_logger_apidemo.logging
{
    public class CemsLogger : ILogger
    {
        private static object _lock = new Object();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;


        private CemsLoggerSender CemsLoggerSender { get; set; }

        public CemsLogger(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
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

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (_lock)
            {
                var dataJSonString = SerializeLog(exception);
                CemsLoggerSender.SendLog(dataJSonString);
            }
        }


        private string SerializeLog(Exception e)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var unixTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

            var ex = e.Demystify();
            var stackTrace = new StackTrace(ex, true);
            // stacktrace has everything private so serialization not works 
            var stackFrames = new List<object>();
            foreach (var stackFrame in stackTrace.GetFrames())
            {
                var frame = new
                {
                    File = stackFrame.GetFileName(),
                    Method = stackFrame.GetMethod().Name,
                    Line = stackFrame.GetFileLineNumber(),
                    Column = stackFrame.GetFileColumnNumber(),
                };
                stackFrames.Add(frame);
            }

            var serializedStackFrames = JsonConvert.SerializeObject(stackFrames);

            var filteredRequestProperties = new FilteredRequestProperties
            {
                Body = "",
                Headers = httpContext.Request.Headers,
                Host = httpContext.Request.Host.ToString(),
                IsHttps = httpContext.Request.IsHttps,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                PathBase = httpContext.Request.PathBase,
                Protocol = httpContext.Request.Protocol,
                Query = JsonConvert.SerializeObject(httpContext.Request.Query),
                QueryString = httpContext.Request.QueryString.ToString(),
                Scheme = httpContext.Request.Scheme
            };

            var filteredConnectionProperties = new FilteredConnectionProperties
            {
                LocalIpAddressV4 = httpContext.Connection.LocalIpAddress.MapToIPv4().ToString(),
                LocalIpAddressV6 = httpContext.Connection.LocalIpAddress.MapToIPv6().ToString(),
                LocalPort = httpContext.Connection.LocalPort,
                RemoteIpAddressV4 = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString(),
                RemoteIpAddressV6 = httpContext.Connection.RemoteIpAddress.MapToIPv6().ToString(),
                RemotePort = httpContext.Connection.RemotePort
            };

            var obj = new DotnetExceptionDto
            {
                Message = ex.Message,
                StackTrace = serializedStackFrames,
                Source = ex.Source,
                ProgLanguage = "C#",
                Timestamp = unixTime,
                ConnectionInfo = filteredConnectionProperties,
                Request = filteredRequestProperties,
                Host = _configuration["HostListen"],
                Port = _configuration["PortListen"]
            };

            return JsonConvert.SerializeObject(obj);
        }
    }
}
