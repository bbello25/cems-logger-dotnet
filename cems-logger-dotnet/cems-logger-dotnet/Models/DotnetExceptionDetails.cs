namespace cems_logger_dotnet.Models
{
    public class DotnetExceptionDetails
    {
        public DotnetStackTrace DotnetStackTrace { get; set; }

        public DotnetExceptionDetails()
        {
            DotnetStackTrace = new DotnetStackTrace();
        }
    }
}