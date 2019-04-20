namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsHttpContext
    {
        ICemsRequestProperties Request { get; set; }
        ICemsConnectionInfo Connection { get; set; }
        string User { get; set; }
    }
}