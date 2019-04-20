using System.Collections.Generic;
using cems_logger_dotnet.Interfaces;

namespace cems_logger_dotnet.Models
{
    class CemsExceptionDetails : ICemsExceptionDetails
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string RawStackTrace { get; set; }
    }
}