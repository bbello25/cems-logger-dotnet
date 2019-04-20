using cems_logger_dotnet.Interfaces;

namespace cems_logger_dotnet.Models
{
    class CemsConnectionInfo : ICemsConnectionInfo
    {
        public string LocalIpAddressV4 { get; set; }
        public string LocalIpAddressV6 { get; set; }
        public int LocalPort { get; set; }
        public string RemoteIpAddressV4 { get; set; }
        public string RemoteIpAddressV6 { get; set; }
        public int RemotePort { get; set; }
    }
}