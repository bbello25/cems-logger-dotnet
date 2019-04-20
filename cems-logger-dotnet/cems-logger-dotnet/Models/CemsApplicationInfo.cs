using cems_logger_dotnet.Interfaces;

namespace cems_logger_dotnet.Models
{
    class CemsApplicationInfo : ICemsApplicationInfo
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string HostName { get; set; }
        public string Os { get; set; }
        public string Environment { get; set; }
        public string AssemblyVersion { get; set; }
    }
}