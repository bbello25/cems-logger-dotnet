namespace cems_logger_dotnet.Models
{
    public class CemsStackFrame
    {
        public string File { get; set; }
        public string Method { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
}