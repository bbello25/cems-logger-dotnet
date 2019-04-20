namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsApplicationInfo
    {
        string Name { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string HostName { get; set; }
        string Os { get; set; }
        string Environment { get; set; }
        string AssemblyVersion { get; set; }
    }
}