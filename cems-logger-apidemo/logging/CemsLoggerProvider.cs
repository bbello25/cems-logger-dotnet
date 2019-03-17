using Microsoft.Extensions.Logging;


namespace cems_logger_apidemo.logging
{
    public class CemsLoggerProvider : ILoggerProvider
    {
        private readonly ILogger _cemsLogger;

        public CemsLoggerProvider(ILogger cemsLogger)
        {
            _cemsLogger = cemsLogger;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _cemsLogger;
        }

        public void Dispose()
        {
        }
    }
}
