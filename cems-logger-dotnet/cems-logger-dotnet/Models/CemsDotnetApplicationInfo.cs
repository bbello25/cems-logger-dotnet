using cems_logger_dotnet.Interfaces;

namespace cems_logger_dotnet.Models
{
    class CemsDotnetApplicationInfo : ICemsDotnetApplicationInfo
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Hostname { get; set; }
        public string Os { get; set; }
        public string AssemblyVersion { get; set; }
    }
}