using System;
using System.Collections.Generic;
using System.Text;

namespace cems_logger_dotnet.Models
{
    public class DotnetStackTrace
    {
        public List<CemsStackFrame> StackFrames { get; set; }
        public double Distance { get; set; }
    }
}
