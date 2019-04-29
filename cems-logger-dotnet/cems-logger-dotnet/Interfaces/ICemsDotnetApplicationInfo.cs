namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsDotnetApplicationInfo
    {
         string Host { get; set; }
         string Port { get; set; }
         string Hostname { get; set; }
         string Os { get; set; }
         string AssemblyVersion { get; set; }
    }
}