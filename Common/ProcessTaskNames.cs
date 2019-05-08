using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ProcessTaskNames
    {
        public const string ProcessStart = "ProcessStart";
        public const string ProcessStop = "ProcessStop";
        public const string ThreadStart = "ThreadStart";
        public const string ThreadStop = "ThreadStop";
        public const string IoPriorityChange = "IoPriorityChange";
        public const string PagePriorityChange = "PagePriorityChange";
        public const string ImageLoad = "ImageLoad";
        public const string ImageUnload = "ImageUnload";
        public const string CpouBasePriorityChange = "CpuBasePriorityChange";
        public const string CpuPriorityChange = "CpuPriorityChange";
    }

    public static class ProcessEventProperty
    {
        public const string ProcessID = "ProcessID";
        public const string ImageName = "ImageName";
        public const string ParentProcessID = "ParentProcessID";
        public const string ExitCode = "ExitCode";
        public const string ExitTime = "ExitTime";
        public const string CreateTime = "CreateTime";
        public const string FormattedMessage = "FormattedMessage";
        public const string SessionID = "SessionID";
        public const string ThreadID = "ThreadID";
        public const string CycleTime = "CycleTime";
        public const string EventName = "EventName";
        public const string ProviderName = "ProviderName";
        public const string Time = "Time";
    }
}
