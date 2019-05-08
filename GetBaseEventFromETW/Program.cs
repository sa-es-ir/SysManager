using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Threading.Tasks;
using System.Threading;
using Diagnostics.Tracing;
using Diagnostics.Tracing.Parsers;
using System.Diagnostics;
using System.IO;
using System.Management;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GetBaseEventFromETW
{
    class Program
    {
        public static object loc = new object();
        public static Semaphore sm = new Semaphore(1, 1);
        public static GetEventClass gec = new GetEventClass();
        static int Main(string[] args)
        {
            
            

            Console.Title = "SysManager";
            //using (var sw = new StreamWriter(@"E:\EventLogInCS\PropertyInfo.txt"))
            //{
            //    sw.Write(FillPropertyInfo(new NetworkEvent()));
            //}
            //Environment.Exit(0);
            GetRuleConfig();
            ProcessEvent proEvent = new ProcessEvent();
            RegistryEvent regEvent = new RegistryEvent();
            NetworkEvent netEvent = new NetworkEvent();
            FileEvent fileEvent = new FileEvent();

            Console.WriteLine("Please Choose One Operation To Manage Your System:");
            int opi;
            while (true)
            {
                Console.WriteLine("For Process Enter 1");
                Console.WriteLine("For Reistry Enter 2");
                Console.WriteLine("For Network Enter 3");
                Console.WriteLine("For File Enter 4");


                Console.Write("Enter Your Choice:");
                var op = Console.ReadLine();

                if (int.TryParse(op, out opi))
                {
                    if (opi < 5 && opi > 0)
                    {
                        gec.Operation = opi;
                        PipLineManager.operation = opi;
                        break;
                    }
                }
                Console.WriteLine(">>>>>>>>>>  Please Enter A Right One!  <<<<<<<<<<<");
            }
            Console.Clear();
            Thread th = new Thread(FireForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

            var pipe = PipLineManager.FileAccessCount;
            var processUseNetWork = PipLineManager.ProcessUseNetwork;
            var processDic = PipLineManager.ProcessDictionary;
            var NetUsage = PipLineManager.NetworkUsage;
            var netu = PipLineManager.netU;
            var regDic = PipLineManager.RegistryUsage;
            var fileEvents = PipLineManager.FileEvents;
            uint pid = 0;

            Action saveLogAction = null;
            saveLogAction = async () =>
            {
                var conqueEvents = gec.ConqueEvent;
                if (conqueEvents.Count > 0)
                {
                    string da;
                    while (conqueEvents.TryDequeue(out da))
                    {
                        var desxml = JsonConvert.DeserializeXmlNode(da);
                        #region Process

                        if (opi == 1)
                        {
                            int procid = desxml.DocumentElement.HasAttribute("ProcessID")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("ProcessID"))
                                : -1;
                            proEvent.ProcessId = procid;
                            int pprocid;
                            if (int.TryParse(desxml.DocumentElement.GetAttribute(ProcessEventProperty.ParentProcessID),
                                out pprocid))
                            {
                                var imagename = desxml.DocumentElement.HasAttribute("ImageName")
                                    ? desxml.DocumentElement.GetAttribute("ImageName")
                                    : "";
                                proEvent.ProcessImage = imagename;
                                await Task.Run(() => { GetProcessInfo(proEvent, proEvent.ProcessId, pprocid, EventName.Process, imagename, proEvent.ProcessId.ToString()); });
                            }
                            else
                            {
                                await Task.Run(() => { GetProcessInfo(proEvent, procid, null, EventName.Process, null); });
                            }

                            proEvent.ThreadId = desxml.DocumentElement.HasAttribute("TID")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("TID"))
                                : -1;
                            proEvent.StartAddress = desxml.DocumentElement.HasAttribute("StartAddress")
                                ? desxml.DocumentElement.GetAttribute("StartAddress")
                                : "";
                            proEvent.Win32StartAddress = desxml.DocumentElement.HasAttribute("Win32StartAddress")
                                ? desxml.DocumentElement.GetAttribute("Win32StartAddress")
                                : "";
                            proEvent.CycleTime = desxml.DocumentElement.HasAttribute("CycleTime")
                                ? long.Parse(desxml.DocumentElement.GetAttribute("CycleTime"))
                                : -1;
                            proEvent.FormattedMessage = desxml.DocumentElement.HasAttribute("FormattedMessage")
                                ? desxml.DocumentElement.GetAttribute("FormattedMessage")
                                : "";
                            proEvent.CreateTime = desxml.DocumentElement.HasAttribute("CreateTime")
                                ? desxml.DocumentElement.GetAttribute("CreateTime")
                                : "";
                            proEvent.TaskName = desxml.DocumentElement.HasAttribute("TaskName")
                                ? desxml.DocumentElement.GetAttribute("TaskName")
                                : "";
                            proEvent.SessionId = desxml.DocumentElement.HasAttribute("SessionId")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("SessionId"))
                                : -1;
                            proEvent.ProviderName = desxml.DocumentElement.HasAttribute("ProviderName")
                                ? desxml.DocumentElement.GetAttribute("ProviderName")
                                : "";
                            proEvent.EventName = desxml.DocumentElement.HasAttribute("EventName")
                                ? desxml.DocumentElement.GetAttribute("EventName")
                                : "";
                            if (proEvent.EventName == "ProcessStop/Stop")
                            {
                                proEvent.ExitTime = desxml.DocumentElement.HasAttribute("Time")
                                    ? desxml.DocumentElement.GetAttribute("Time")
                                    : "";
                                proEvent.ExitCode = desxml.DocumentElement.HasAttribute("ExitCode")
                                    ? int.Parse(desxml.DocumentElement.GetAttribute("ExitCode"))
                                    : -1;
                                //string mgs;
                                //processDic.TryRemove(proEvent.ProcessName, out mgs);
                            }
                            else
                            {
                                processDic.AddOrUpdate(proEvent.ProcessName ?? "--", proEvent.ProcessHistory,
                                (key, value) => proEvent.ProcessHistory);
                            }

                        }
                        #endregion
                        #region Registry

                        else if (opi == 2)
                        {
                            regEvent.ProcessId = desxml.DocumentElement.HasAttribute("PID")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("PID"))
                                : -1;
                            await Task.Run(() => { GetProcessInfo(regEvent, regEvent.ProcessId, null, EventName.Registry, null); });
                            regEvent.BaseName = desxml.DocumentElement.HasAttribute("BaseName")
                                ? desxml.DocumentElement.GetAttribute("BaseName")
                                : "";
                            regEvent.BaseObject = desxml.DocumentElement.HasAttribute("BaseObject")
                                ? desxml.DocumentElement.GetAttribute("BaseObject")
                                : "";
                            regEvent.CapturedData = desxml.DocumentElement.HasAttribute("CapturedData")
                                ? desxml.DocumentElement.GetAttribute("CapturedData")
                                : "";
                            regEvent.CapturedDataSize = desxml.DocumentElement.HasAttribute("CapturedDataSize")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("CapturedDataSize"))
                                : -1;
                            regEvent.DataSize = desxml.DocumentElement.HasAttribute("DataSize")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("DataSize"))
                                : -1;
                            regEvent.EventName = desxml.DocumentElement.HasAttribute("EventName")
                                ? desxml.DocumentElement.GetAttribute("EventName")
                                : "";
                            regEvent.ProviderName = desxml.DocumentElement.HasAttribute("ProviderName")
                                ? desxml.DocumentElement.GetAttribute("ProviderName")
                                : "";
                            regEvent.Disposition = desxml.DocumentElement.HasAttribute("Disposition")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("Disposition"))
                                : -1;
                            regEvent.KeyName = desxml.DocumentElement.HasAttribute("KeyName")
                                ? desxml.DocumentElement.GetAttribute("KeyName")
                                : "";
                            regEvent.KeyObject = desxml.DocumentElement.HasAttribute("KeyObject")
                                ? desxml.DocumentElement.GetAttribute("KeyObject")
                                : "";
                            regEvent.PreviousData = desxml.DocumentElement.HasAttribute("PreviousData")
                                ? desxml.DocumentElement.GetAttribute("PreviousData")
                                : "";
                            regEvent.PreviousDataCapturedSize =
                                desxml.DocumentElement.HasAttribute("PreviousDataCapturedSize")
                                    ? int.Parse(desxml.DocumentElement.GetAttribute("PreviousDataCapturedSize"))
                                    : -1;
                            regEvent.PreviousDataSize = desxml.DocumentElement.HasAttribute("PreviousDataSize")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("PreviousDataSize"))
                                : -1;
                            regEvent.PreviousDataType = desxml.DocumentElement.HasAttribute("PreviousDataType")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("PreviousDataType"))
                                : -1;
                            regEvent.RelativeName = desxml.DocumentElement.HasAttribute("RelativeName")
                                ? desxml.DocumentElement.GetAttribute("RelativeName")
                                : "";
                            regEvent.ThreadId = desxml.DocumentElement.HasAttribute("TID")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("TID"))
                                : -1;
                            regEvent.Type = desxml.DocumentElement.HasAttribute("Type")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("Type"))
                                : -1;
                            regEvent.ValueName = desxml.DocumentElement.HasAttribute("ValueName")
                                ? desxml.DocumentElement.GetAttribute("ValueName")
                                : "";
                            //sw.WriteLine(regEvent.ProviderName + regEvent.EventName + regEvent.ProcessHistory);
                            RegistryUtility(regDic, regEvent);
                        }
                        #endregion
                        #region Network
                        else if (opi == 3)
                        {
                            netEvent.ProcessId = desxml.DocumentElement.HasAttribute("PID") ? int.Parse(desxml.DocumentElement.GetAttribute("PID")) : -1;
                            netEvent.ProcessId = desxml.DocumentElement.HasAttribute("PIDD") ? int.Parse(desxml.DocumentElement.GetAttribute("PIDD")) : -1;
                            await Task.Run(() => { GetProcessInfo(netEvent, netEvent.ProcessId, null, EventName.Network); });
                            netEvent.ProviderName = desxml.DocumentElement.HasAttribute("ProviderName") ? desxml.DocumentElement.GetAttribute("ProviderName") : "";
                            netEvent.EventName = desxml.DocumentElement.HasAttribute("EventName") ? desxml.DocumentElement.GetAttribute("EventName") : "";
                            netEvent.DestinationAddress = desxml.DocumentElement.HasAttribute("daddr") ? Utility.LongToIpAddress(desxml.DocumentElement.GetAttribute("daddr")) : "-1";
                            netEvent.SourceAddress = desxml.DocumentElement.HasAttribute("saddr") ? Utility.LongToIpAddress(desxml.DocumentElement.GetAttribute("saddr")) : "-1";
                            netEvent.Dport = desxml.DocumentElement.HasAttribute("dport") ? int.Parse(desxml.DocumentElement.GetAttribute("dpoort")) : -1;
                            netEvent.Sport = desxml.DocumentElement.HasAttribute("sport") ? int.Parse(desxml.DocumentElement.GetAttribute("sport")) : -1;
                            netEvent.ConnId = desxml.DocumentElement.HasAttribute("connid") ? int.Parse(desxml.DocumentElement.GetAttribute("connid")) : -1;
                            netEvent.SeqNum = desxml.DocumentElement.HasAttribute("seqnum") ? int.Parse(desxml.DocumentElement.GetAttribute("seqnum")) : -1;
                            netEvent.ThreadId = desxml.DocumentElement.HasAttribute("TID") ? int.Parse(desxml.DocumentElement.GetAttribute("TID")) : -1;
                            netEvent.Size = desxml.DocumentElement.HasAttribute("size") ? int.Parse(desxml.DocumentElement.GetAttribute("size")) : 0;
                            //Task.Run(() => { NetworkUtility(netu, netEvent, processUseNetWork, netEvent.ProcessHistoryD, netEvent.SourceAddress, netEvent.DestinationAddress); });
                            NetUsage.Enqueue(netEvent);
                        }
                        #endregion
                        #region File
                        else
                        {
                            fileEvent.ProcessId = desxml.DocumentElement.HasAttribute("PID")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("PID"))
                                : -1;
                            await Task.Run(() => { GetProcessInfo(fileEvent, fileEvent.ProcessId, null, EventName.File); });
                            fileEvent.ThreadId = desxml.DocumentElement.HasAttribute("TID")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("TID"))
                                : -1;
                            fileEvent.FileName = desxml.DocumentElement.HasAttribute("FileName")
                                ? desxml.DocumentElement.GetAttribute("FileName")
                                : "";
                            fileEvent.FilePath = desxml.DocumentElement.HasAttribute("FilePath")
                                ? desxml.DocumentElement.GetAttribute("FilePath")
                                : "";
                            fileEvent.ProviderName = desxml.DocumentElement.HasAttribute("ProviderName")
                                ? desxml.DocumentElement.GetAttribute("ProviderName")
                                : "";
                            fileEvent.EventName = desxml.DocumentElement.HasAttribute("EventName")
                                ? desxml.DocumentElement.GetAttribute("EventName")
                                : "";
                            fileEvent.Irp = desxml.DocumentElement.HasAttribute("Irp")
                                ? desxml.DocumentElement.GetAttribute("Irp")
                                : "";
                            fileEvent.FileObject = desxml.DocumentElement.HasAttribute("FileObject")
                                ? desxml.DocumentElement.GetAttribute("FileObject")
                                : "";

                            //fileEvent.IssuingThreadId = desxml.DocumentElement.HasAttribute("IssuingThreadId")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("IssuingThreadId"))
                            //    : -1;
                            //fileEvent.CreateOptions = desxml.DocumentElement.HasAttribute("CreateOptions")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("CreateOptions"))
                            //    : -1;
                            //fileEvent.CreateAttributes = desxml.DocumentElement.HasAttribute("CreateAttributes")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("CreateAttributes"))
                            //    : -1;
                            fileEvent.ShareAccess = desxml.DocumentElement.HasAttribute("ShareAccess")
                                ? desxml.DocumentElement.GetAttribute("ShareAccess")
                                : "";
                            fileEvent.FileKey = desxml.DocumentElement.HasAttribute("FileKey")
                                ? desxml.DocumentElement.GetAttribute("FileKey")
                                : "";
                            //long iit = Convert.ToInt64(fileEvent.FileKey, 16)*-1;

                            // var filena = Utility.GetFileNameFromHandle(new IntPtr(Convert.ToInt64(fileEvent.FileKey, 16)));
                            fileEvent.IOSize = desxml.DocumentElement.HasAttribute("IOSize")
                                ? int.Parse(desxml.DocumentElement.GetAttribute("IOSize"))
                                : -1;
                            //fileEvent.IOFlags = desxml.DocumentElement.HasAttribute("IOFlags")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("IOFlags"))
                            //    : -1;
                            //fileEvent.ExtraFlags = desxml.DocumentElement.HasAttribute("ExtraFlags")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("ExtraFlags"))
                            //    : -1;
                            //fileEvent.ByteOffset = desxml.DocumentElement.HasAttribute("ByteOffset")
                            //    ? long.Parse(desxml.DocumentElement.GetAttribute("ByteOffset"))
                            //    : -1;
                            //fileEvent.ExtraInformation = desxml.DocumentElement.HasAttribute("ExtraInformation")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("ExtraInformation"))
                            //    : -1;
                            //fileEvent.Status = desxml.DocumentElement.HasAttribute("Status")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("Status"))
                            //    : -1;
                            //fileEvent.InfoClass = desxml.DocumentElement.HasAttribute("InfoClass")
                            //    ? int.Parse(desxml.DocumentElement.GetAttribute("InfoClass"))
                            //    : -1;
                            Task.Run(() => { FileUtility(fileEvents,pipe, fileEvent); });

                        }

                        #endregion
                    }
                }
                try
                {
                    Thread.Sleep(500);
                    Parallel.Invoke(saveLogAction);
                }
                catch (Exception)
                {
                    Thread.Sleep(500);
                    saveLogAction.Invoke();
                }

            };
            Task t = new Task(() => { gec.FetchEvents(); });
            t.Start();
            saveLogAction.Invoke();
            Console.Read();
            return 0;
        }

        [STAThread]
        private static void FireForm()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form3());
            Application.DoEvents();
        }

        static readonly ManagementObjectSearcher searcher = new ManagementObjectSearcher();
        static ManagementObjectCollection _collection;
        static readonly ObjectQuery q = new ObjectQuery();

        static void GetProcessInfo<T>(T ob, int procId, int? parentPId, EventName eventName, string procImage = null, string imageId = null)
        {
            string ps = procId + " --> ";
            uint pid = 0;
            bool flagForIdle = false;
            var obj = ob;
            var procObject = typeof(T);
            Func<uint, bool, string> DoAction = null;
            //<-- Check if process is valid or not to run 
            //var path = Utility.GetExecutePath(procId);
            if (eventName == EventName.Process && procId != 0 && !string.IsNullOrEmpty(procImage) && !HashClass.IsValidHashProcess(HashClass.GetHashFile(procImage, new SHA512CryptoServiceProvider()))
                && ProcessToSkipList.ProcessNames.FirstOrDefault(x => procImage.ToLower().Contains(x.ProcessName.ToLower())) == null)
            {
                var pat = procImage;
                HashClass.UnPermittedProcess.Add(Path.GetFileName(pat) + "(ID:" + (imageId ?? "0") + ")");
                var kill = ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == eventName);
                if (kill != null && kill.KillOrSuspend == 1)
                {
                    try
                    {
                        Process.GetProcessById(int.Parse(imageId??"-1")).Kill();
                    }
                    catch
                    {
                    }
                }
            }

            DoAction = (p, isParentProcess) =>
            {
                q.QueryString = "SELECT Name,CommandLine,ExecutablePath,ParentProcessId FROM Win32_Process Where ProcessId=" + p;
                searcher.Query = q;
                _collection = searcher.Get();
                if (_collection.Count > 0)
                {
                    foreach (var item in _collection)
                    {
                        var name = item["Name"].ToString();
                        var commandLine = item["CommandLine"] != null ? item["CommandLine"].ToString() : string.Empty;
                        //var executablePath = item["ExecutablePath"] != null ? item["ExecutablePath"].ToString() : string.Empty;
                        var parentProcessId = item["ParentProcessId"] != null ? item["ParentProcessId"].ToString() : string.Empty;
                        if (name.ToLower().Contains("wmiprvse") && gec.WmiPreId == "0")
                            gec.WmiPreId = p.ToString();
                        //<-- Rules
                        if (eventName == EventName.File)
                        {
                            if (
                                ProcessToSkipList.ProcessNames.FirstOrDefault(
                                    x => name.ToLower().Contains(x.ProcessName.ToLower())) == null)
                            {
                                var kill = ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == eventName);
                                if (kill!=null && kill.KillOrSuspend == 1)
                                {
                                    try
                                    {
                                        Process.GetProcessById((int) p).Kill();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        else if (eventName == EventName.Registry)
                        {
                            if (
                                ProcessToSkipList.ProcessNames.FirstOrDefault(
                                    x => name.ToLower().Contains(x.ProcessName.ToLower())) == null)
                            {
                                var kill = ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == eventName);
                                if (kill != null && kill.KillOrSuspend == 1)
                                {
                                    try
                                    {
                                        Process.GetProcessById((int)p).Kill();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        else if (eventName == EventName.Network)
                        {
                            if (
                                ProcessToSkipList.ProcessNames.FirstOrDefault(
                                    x => name.ToLower().Contains(x.ProcessName.ToLower())) == null)
                            {
                                var kill = ProcessToSkipList.KillOrSuspendList.FirstOrDefault(x => x.EventName == eventName);
                                if (kill != null && kill.KillOrSuspend == 1)
                                {
                                    try
                                    {
                                        Process.GetProcessById((int)p).Kill();
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        
                        //-->
                        if (!isParentProcess)
                        {
                            var memberInfo = procObject.GetProperty("ProcessName");
                            if (memberInfo != null)
                                memberInfo.SetValue(obj, name);
                            //For Network Event
                            if (eventName == EventName.Network)
                            {
                                var propertyInfo = procObject.GetProperty("ProcessNameD");
                                if (propertyInfo != null)
                                    propertyInfo.SetValue(obj, name);
                            }
                        }

                        ps += commandLine + "  ProcessName: *" + name + "* --> ";
                        try
                        {
                            pid = uint.Parse(parentProcessId);
                            ps += parentProcessId + " --> ";
                            if (pid == 0)
                            {
                                flagForIdle = true;
                            }
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                    if (!flagForIdle)
                    {
                        DoAction.Invoke(pid, true);
                    }
                }
                return ps;
            };
            if (procImage != null)
            {
                string pname = Path.GetFileName(procImage);
                ps += procImage + " --> " + " ProcessName: *" + pname + "* --> ";
                var propertyInfo = procObject.GetProperty("ProcessImage");
                if (propertyInfo != null)
                    propertyInfo.SetValue(obj, procImage);
                var memberInfo = procObject.GetProperty("ProcessName");
                if (memberInfo != null)
                    memberInfo.SetValue(obj, pname);
            }
            if (parentPId.HasValue && eventName != EventName.Network)
            {
                ps += parentPId;
                var propertyInfo = procObject.GetProperty("ParentProcessId");
                if (propertyInfo != null)
                    propertyInfo.SetValue(obj, parentPId);
                string ph = DoAction.Invoke((uint)parentPId, true);
                var memberInfo = procObject.GetProperty("ProcessHistory");
                if (memberInfo != null)
                    memberInfo.SetValue(obj, ph);
            }
            else
            {
                string ph = DoAction.Invoke((uint)procId, false);
                var propertyInfo = procObject.GetProperty("ProcessHistory");
                if (propertyInfo != null)
                    propertyInfo.SetValue(obj, ph);
                if (eventName == EventName.Network)
                {
                    ph = DoAction.Invoke((uint)procId, false);
                    var memberInfo = procObject.GetProperty("ProcessHistoryD");
                    if (memberInfo != null)
                        memberInfo.SetValue(obj, ph);
                }
            }
        }
        static string FillPropertyInfo<T>(T obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in typeof(T).GetProperties())
            {
                sb.Append("netEvent." + item.Name + " = desxml.DocumentElement.HasAttribute(\"" + item.Name + "\")? desxml.DocumentElement.GetAttribute(\"" + item.Name + "\"): \"\";" + "\r\n");
            }
            return sb.ToString();
        }

        private static ConcurrentQueue<NetworkEvent> nete = PipLineManager.NetworkUsage;

        static void NetworkUtility(ConcurrentDictionary<string, NetworkEvent> netu, NetworkEvent netEvent, ConcurrentQueue<string> list, string data, decimal saddr, decimal daddr)
        {
            //nete.Enqueue(netEvent);
            netu.AddOrUpdate(netEvent.ProcessName, netEvent, (key, value) => netEvent);
            //foreach (var item in list)
            //{
            //    if (data.Contains(item))
            //    {
            //        PipLineManager.WriteFile(data);
            //    }
            //}
        }

        static void FileUtility(ConcurrentQueue<FileEvent> fileEvents ,ConcurrentDictionary<string, int> pipe, FileEvent fileEvent)
        {
            int fileCount;
            try
            {
                fileEvents.Enqueue(fileEvent);
                if (int.TryParse(pipe.FirstOrDefault(x => x.Key == fileEvent.ProcessName).Value.ToString(), out fileCount))
                {
                    pipe.AddOrUpdate(fileEvent.ProcessName, fileCount + 1, (key, oldvalue) => fileCount + 1);
                }

            }
            catch
            {
            }

        }

        static void RegistryUtility(ConcurrentQueue<RegistryEvent> regQueue, RegistryEvent reg)
        {
            regQueue.Enqueue(reg);
        }

        static void GetRuleConfig()
        {
            //get hash file to find permissionable process
            var hashfiles = File.ReadAllText(Directory.GetCurrentDirectory() + @"\PermissibleFile.txt", Encoding.UTF8);
            if (hashfiles != string.Empty)
                HashFileListClass.HashList =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<List<HashFileClass>>(hashfiles);

            var hashfiles_p = File.ReadAllText(Directory.GetCurrentDirectory() + @"\ProcessToSkip.txt", Encoding.UTF8);
            if (hashfiles_p != string.Empty)
            {
                var result_p = Newtonsoft.Json.JsonConvert.DeserializeObject<ProcessSkipToSave>(hashfiles_p);
                ProcessToSkipList.ProcessNames = result_p.ProcessSkipList;
                ProcessToSkipList.KillOrSuspendList = result_p.KillOrSuspend;

            }

            //get directory to watch file events
            var paths = File.ReadAllText(Directory.GetCurrentDirectory() + @"\FileEventConfig.txt", Encoding.UTF8);
            if (paths != string.Empty)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<PathToWatchSave>(paths);
                PathToWatchList.PathToWatches = result.PathList;
                PathToWatchList.PathToWatches.ForEach(x => x.Path = x.Path.ToLower());
                PathToWatchList.FileCount = result.FileCount;
            }
            //get key paths to watch registry events
            var keys = File.ReadAllText(Directory.GetCurrentDirectory() + @"\RegistryEventConfig.txt", Encoding.UTF8);
            if (keys != string.Empty)
            {
                KeyToWatchList.KeyToWatches = Newtonsoft.Json.JsonConvert.DeserializeObject<List<KeyToWatch>>(keys);
                KeyToWatchList.KeyToWatches.ForEach(x => x.Key = x.Key.ToLower());
            }
            //get net config
            var netconfig = File.ReadAllText(Directory.GetCurrentDirectory() + @"\NetworkEventConfig.txt", Encoding.UTF8);
            if (netconfig != string.Empty)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<NetConfigSave>(netconfig);
                NetConfigList.IpToWatches = result.IpConfigs;
                NetConfigList.PortToWatches = result.PortConfigs;
            }
        }
    }
}
