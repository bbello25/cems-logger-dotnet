using System;
using cems_logger_dotnet.Models;

namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsLogEvent
    {
        ICemsApplicationInfo DotnetApplicationInfo { get; set; }
        ICemsExceptionDetails ExceptionDetails { get; set; }
        DotnetExceptionDetails DotnetExceptionDetails { get; set; }
        ICemsHttpContext DotnetHttpContext { get; set; }

        int Platform { get; set; }
        DateTime Timestamp { get; set; }
    }
}