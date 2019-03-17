using Microsoft.AspNetCore.Http;

namespace cems_logger_apidemo.logging
{
    public class FilteredRequestProperties
    {
        public string Body { get; set; }
        public IHeaderDictionary Headers { get; set; }
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
