using System.Collections.Generic;
using cems_logger_dotnet.Models;

namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsExceptionDetails
    {
        string Message { get; set; }
        string Type { get; set; }
        string Source { get; set; }
        string RawStackTrace { get; set; }
    }
}