namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsRequestProperties
    {
        string Body { get; set; }
        string HeadersJson { get; set; }
        string Host { get; set; }
        bool IsHttps { get; set; }
        string Method { get; set; }
        string Path { get; set; }
        string PathBase { get; set; }
        string Protocol { get; set; }
        string Query { get; set; }
        string QueryString { get; set; }
        string Scheme { get; set; }
    }
}