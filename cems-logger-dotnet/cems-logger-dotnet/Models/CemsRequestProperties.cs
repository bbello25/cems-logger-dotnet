using cems_logger_dotnet.Interfaces;

namespace cems_logger_dotnet.Models
{
    class CemsRequestProperties : ICemsRequestProperties
    {
        public string Body { get; set; }
        public string HeadersJson { get; set; }
        public string Host { get; set; }
        public bool IsHttps { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string PathBase { get; set; }
        public string Protocol { get; set; }
        public string Query { get; set; }
        public string QueryString { get; set; }
        public string Scheme { get; set; }
    }
}