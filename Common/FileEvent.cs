using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FileEvent
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessHistory { get; set; }
        public int ThreadId { get; set; }
        public string FileName { get; set; }
        public string ProviderName { get; set; }
        public string EventName { get; set; }
        public string Irp { get; set; }
        public string FileObject { get; set; }
        public int IssuingThreadId { get; set; }
        public long CreateOptions { get; set; }
        public int CreateAttributes { get; set; }
        public string ShareAccess { get; set; }
        public string FileKey { get; set; }
        public int IOSize { get; set; }
        public int IOFlags { get; set; }
        public int ExtraFlags { get; set; }
        public long ByteOffset { get; set; }
        public int ExtraInformation { get; set; }
        public int Status { get; set; }
        public int InfoClass { get; set; }
        public string FilePath { get; set; }


    }
}
