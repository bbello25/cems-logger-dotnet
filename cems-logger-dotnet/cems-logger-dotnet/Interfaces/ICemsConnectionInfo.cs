namespace cems_logger_dotnet.Interfaces
{
    public interface ICemsConnectionInfo
    {
        string LocalIpAddressV4 { get; set; }
        string LocalIpAddressV6 { get; set; }
        int LocalPort { get; set; }
        string RemoteIpAddressV4 { get; set; }
        string RemoteIpAddressV6 { get; set; }
        int RemotePort { get; set; }
    }
}