using System.Diagnostics;

namespace cems_logger_apidemo.logging
{
    public class DotnetExceptionDto
    {
        public string Message { get; set; }
        public StackTrace StackTrace { get; set; }
        public string Source { get; set; }
        public string ProgLanguage { get; set; }
        public long Timestamp { get; set; }
        public FilteredConnectionProperties ConnectionInfo { get; set; }
        public FilteredRequestProperties Request { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }
}