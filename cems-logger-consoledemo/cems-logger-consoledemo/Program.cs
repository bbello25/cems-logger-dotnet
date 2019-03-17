using cems_logger_dotnet;
using System;

namespace cems_logger_consoledemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new CemsLoggerSender("otktqinesgatepagsvv4fkcre4zm0i", "dotnet console");
        }
    }
}
