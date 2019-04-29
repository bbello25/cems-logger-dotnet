using System;
using System.Collections.Generic;
using System.Diagnostics;
using cems_logger_dotnet.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace cems_logger_dotnet.Models
{
    public class CemsLogEvent : ICemsLogEvent
    {
        public ICemsApplicationInfo ApplicationInfo { get; set; }
        public ICemsDotnetApplicationInfo DotnetApplicationInfo { get; set; }
        public ICemsExceptionDetails ExceptionDetails { get; set; }
        public DotnetExceptionDetails DotnetExceptionDetails { get; set; }
        public ICemsHttpContext DotnetHttpContext { get; set; }
        public int Platform { get; set; }
        public DateTime Timestamp { get; set; }

        public CemsLogEvent()
        {
            Platform = 1;
            Timestamp = DateTime.Now;
            DotnetApplicationInfo = new CemsDotnetApplicationInfo();
            ApplicationInfo = new CemsApplicationInfo();
            ExceptionDetails = new CemsExceptionDetails();
            DotnetHttpContext = new CemsHttpContext();
            DotnetExceptionDetails = new DotnetExceptionDetails();
        }

        public void AddExceptionDetails(Exception e)
        {
            ExceptionDetails.Message = e.Message;
            ExceptionDetails.Source = e.Source;
            ExceptionDetails.Type = e.GetType().Name;
            ExceptionDetails.RawStackTrace = e.StackTrace;

            var stackTrace = new StackTrace(e, true);

            var csharpStackFrames = stackTrace.GetFrames();
            if (csharpStackFrames != null)
            {
                var stackFrames = new List<CemsStackFrame>();
                foreach (var stackFrame in csharpStackFrames)
                {
                    var frame = new CemsStackFrame
                    {
                        File = stackFrame.GetFileName(),
                        Method = stackFrame.GetMethod().Name,
                        Line = stackFrame.GetFileLineNumber(),
                        Column = stackFrame.GetFileColumnNumber(),
                    };
                    stackFrames.Add(frame);
                }

                DotnetExceptionDetails.DotnetStackTrace.StackFrames = stackFrames;
            }
        }

        public void AddHttpContext(HttpContext httpContext)
        {
            DotnetHttpContext.Request.Body = httpContext.Request.Body.ToString();
            DotnetHttpContext.Request.HeadersJson = JsonConvert.SerializeObject(httpContext.Request.Headers);
            DotnetHttpContext.Request.Host = httpContext.Request.Host.ToString();
            DotnetHttpContext.Request.IsHttps = httpContext.Request.IsHttps;
            DotnetHttpContext.Request.Method = httpContext.Request.Method;
            DotnetHttpContext.Request.Path = httpContext.Request.Path;
            DotnetHttpContext.Request.PathBase = httpContext.Request.PathBase;
            DotnetHttpContext.Request.Protocol = httpContext.Request.Protocol;
            DotnetHttpContext.Request.Query = JsonConvert.SerializeObject(httpContext.Request.Query);
            DotnetHttpContext.Request.QueryString = httpContext.Request.QueryString.ToString();
            DotnetHttpContext.Request.Scheme = httpContext.Request.Scheme;

            DotnetHttpContext.Connection.LocalIpAddressV4 =
                httpContext.Connection.LocalIpAddress.MapToIPv4().ToString();
            DotnetHttpContext.Connection.LocalIpAddressV6 =
                httpContext.Connection.LocalIpAddress.MapToIPv6().ToString();
            DotnetHttpContext.Connection.LocalPort = httpContext.Connection.LocalPort;
            DotnetHttpContext.Connection.RemoteIpAddressV4 =
                httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            DotnetHttpContext.Connection.RemoteIpAddressV6 =
                httpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
            DotnetHttpContext.Connection.RemotePort = httpContext.Connection.RemotePort;
        }
        public void AddApplicationInfo(string name,  string version, string environment)
        {
            ApplicationInfo.Name = name;
            ApplicationInfo.Version = version;
            ApplicationInfo.Environment = environment;
        }
    }
}