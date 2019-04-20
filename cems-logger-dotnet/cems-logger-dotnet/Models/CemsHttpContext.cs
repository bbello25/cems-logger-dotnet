using cems_logger_dotnet.Interfaces;

namespace cems_logger_dotnet.Models
{
    class CemsHttpContext : ICemsHttpContext
    {
        public ICemsRequestProperties Request { get; set; }
        public ICemsConnectionInfo Connection { get; set; }
        public string User { get; set; }

        public CemsHttpContext()
        {
            Request = new CemsRequestProperties();
            Connection = new CemsConnectionInfo();
        }
    }
}