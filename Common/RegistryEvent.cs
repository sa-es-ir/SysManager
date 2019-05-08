using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class RegistryEvent
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessHistory { get; set; }
        public string ProviderName { get; set; }
        public string EventName { get; set; }
        public string RelativeName { get; set; }
        public int Type { get; set; }
        public string KeyName { get; set; }
        public string ValueName { get; set; }
       
        public int ThreadId { get; set; }
        public string KeyObject { get; set; }
        public int DataSize { get; set; }
        public int CapturedDataSize { get; set; }
        public string CapturedData { get; set; }
        public int PreviousDataType { get; set; }
        public int PreviousDataSize { get; set; }
        public int PreviousDataCapturedSize { get; set; }
        public string PreviousData { get; set; }
        
        public int Disposition { get; set; }
        public string BaseName { get; set; }
        public string BaseObject { get; set; }


    }
}
