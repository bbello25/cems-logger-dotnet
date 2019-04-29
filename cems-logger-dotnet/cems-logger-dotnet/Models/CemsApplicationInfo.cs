using cems_logger_dotnet.Interfaces;

namespace cems_logger_dotnet.Models
{
    public class CemsApplicationInfo : ICemsApplicationInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
    }
}