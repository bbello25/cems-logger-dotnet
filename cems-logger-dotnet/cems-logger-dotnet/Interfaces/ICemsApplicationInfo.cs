namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsApplicationInfo
    {
        string Name { get; set; }
        string Version { get; set; }
        string Environment { get; set; }
    }
}