using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    //<-- file event config
    public class PathToWatch
    {
        public string Path { get; set; }
    }

    public class PathToWatchList
    {
        private static readonly List<PathToWatch> _PathToWatches = new List<PathToWatch>();

        public static List<PathToWatch> PathToWatches
        {
            set { _PathToWatches.AddRange(value); }
            get
            {
                if (_PathToWatches != null)
                    return _PathToWatches;
                return new List<PathToWatch>();
            }
        }
        public static int FileCount;
    }

    public class PathToWatchSave
    {
        public List<PathToWatch> PathList;
        public int FileCount;
    }
    //-->
    //<-- registry event config
    public class KeyToWatch
    {
        public string Key { get; set; }
    }

    public class KeyToWatchList
    {
        private static readonly List<KeyToWatch> _KeyToWatches = new List<KeyToWatch>();

        public static List<KeyToWatch> KeyToWatches
        {
            set { _KeyToWatches.AddRange(value); }
            get
            {
                if (_KeyToWatches != null)
                    return _KeyToWatches;
                return new List<KeyToWatch>();
            }
        }
    }
    //-->
    //<-- Network event config
    public class IpConfig
    {
        public string IpAddress { get; set; }
    }
    public class PortConfig
    {
        public string Port { get; set; }
    }

    public class NetConfigList
    {
        private static readonly List<IpConfig> _IpToWatches = new List<IpConfig>();

        public static List<IpConfig> IpToWatches
        {
            set { _IpToWatches.AddRange(value); }
            get
            {
                if (_IpToWatches != null)
                    return _IpToWatches;
                return new List<IpConfig>();
            }
        }

        private static readonly List<PortConfig> _PortToWatches = new List<PortConfig>();

        public static List<PortConfig> PortToWatches
        {
            set { _PortToWatches.AddRange(value); }
            get
            {
                if (_PortToWatches != null)
                    return _PortToWatches;
                return new List<PortConfig>();
            }
        }
    }

    public class NetConfigSave
    {
        public List<IpConfig> IpConfigs { get; set; }
        public List<PortConfig> PortConfigs { get; set; }
    }
    //-->

    //<-- Process to skip
    public class ProcessToSkip
    {
        public string ProcessName { get; set; }
        public EventName EventName { get; set; }// Process, File, Regisrty, Network
    }

    public class KillOrSuspendList
    {
        public int KillOrSuspend { get; set; } // 0: NoAction , 1: kill, 2: suspend
        public EventName EventName { get; set; }
    }
    public class ProcessToSkipList
    {
        private static readonly List<ProcessToSkip> _ProcessNames = new List<ProcessToSkip>();
        public static List<ProcessToSkip> ProcessNames
        {
            set { _ProcessNames.AddRange(value);}
            get { return _ProcessNames ?? new List<ProcessToSkip>(); }
        }
        private static readonly List<KillOrSuspendList> _KillOrSuspendList = new List<KillOrSuspendList>();
        public static List<KillOrSuspendList> KillOrSuspendList
        {
            set { _KillOrSuspendList.AddRange(value); }
            get { return _KillOrSuspendList ?? new List<KillOrSuspendList>(); }
        }
        
    }

    public class ProcessSkipToSave
    {
        public List<ProcessToSkip> ProcessSkipList { get; set; }
        public List<KillOrSuspendList> KillOrSuspend { get; set; } 
    }
    //-->
}
