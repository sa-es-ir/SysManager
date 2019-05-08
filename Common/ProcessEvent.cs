using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ProcessEvent
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessImage { get; set; }
        public int ParentProcessId { get; set; }
        public string ParentProcessName { get; set; }
        public string ParentProcessImage { get; set; }
        public string ProcessHistory { get; set; }
        public int ThreadId { get; set; }
        public string StartAddress { get; set; }
        public string Win32StartAddress { get; set; }
        public long CycleTime { get; set; }
        public string FormattedMessage { get; set; }
        public string CreateTime { get; set; }
        public string ExitTime { get; set; }
        public int ExitCode { get; set; }
        public string TaskName { get; set; }
        public int SessionId { get; set; }
        public string ProviderName { get; set; }
        public string EventName { get; set; }

    }
}
