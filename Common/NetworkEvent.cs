using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class NetworkEvent
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessHistory { get; set; }
        public int ProcessIdD { get; set; }
        public string ProcessNameD { get; set; }
        public string ProcessHistoryD { get; set; }
        public string ProviderName { get; set; }
        public string EventName { get; set; }
        public string DestinationAddress { get; set; }
        public string SourceAddress { get; set; }
        public int Dport { get; set; }
        public int Sport { get; set; }
        public int ConnId { get; set; }
        public int SeqNum { get; set; }
        public int Size { get; set; }
        public int ThreadId { get; set; }
        
    }
}
