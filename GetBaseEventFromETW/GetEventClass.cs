using System;
using System.CodeDom;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Diagnostics.Tracing;
using Diagnostics.Tracing.Parsers;
using Common;
using Diagnostics.Tracing.Parsers;
using System.Diagnostics.Eventing;
using Newtonsoft.Json;
using System.Xml;


namespace GetBaseEventFromETW
{
    public class GetEventClass
    {
        public ConcurrentQueue<string> ConqueEvent = new ConcurrentQueue<string>();
        readonly XmlDocument _xml = new XmlDocument();
        public int Operation = 1;
        /// <summary>
        ///  id for WmiPrvSE.exe to skip event that contains it's id.
        /// because WmiPrvSE.exe use by this application frequently for get process info.
        /// </summary>
        private string _WmiPreId = "0";

        public string WmiPreId
        {
            get { return _WmiPreId; }
            set { _WmiPreId = "PID=\"" + value + "\""; }
        }
        public void FetchEvents()
        {
            var sessionName = "ETWEventSession";
            Action<TraceEvent> logAction = delegate(TraceEvent data)
            {
                string logToMonitor = data.ToString();
                string lg = logToMonitor.ToLower();
                if (WmiPreId != "0" && (logToMonitor.Contains(WmiPreId) || logToMonitor.Contains("wmiprvse")))
                    return;
                if (Operation==4)
                {
                    if (PathToWatchList.PathToWatches.Count > 0)
                    {
                        if (PathToWatchList.PathToWatches.FirstOrDefault(x => lg.Contains(x.Path)) != null)
                        {
                            Console.WriteLine(logToMonitor);
                            _xml.LoadXml(logToMonitor.Replace("/>", " Time=\"" + data.TimeStamp + "\" />"));
                            var xdFile = JsonConvert.SerializeXmlNode(_xml);
                            ConqueEvent.Enqueue(xdFile);
                        }
                    }
                 
                }
                else if (Operation == 2)
                {
                    if (KeyToWatchList.KeyToWatches.Count > 0)
                    {
                        if (KeyToWatchList.KeyToWatches.FirstOrDefault(x => lg.Contains(x.Key)) != null)
                        {
                            Console.WriteLine(logToMonitor);
                            _xml.LoadXml(logToMonitor.Replace("/>", " Time=\"" + data.TimeStamp + "\" />"));
                            var xdFile = JsonConvert.SerializeXmlNode(_xml);
                            ConqueEvent.Enqueue(xdFile);
                        }
                    }
                }
                else if (Operation == 3)
                {

                    if (NetConfigList.IpToWatches.Count > 0 || NetConfigList.PortToWatches.Count > 0)
                    {
                        var firstIndex = logToMonitor.IndexOf("daddr=\"");
                        var lastIndex = logToMonitor.Substring(firstIndex + 7).IndexOf("\"");// 7 is length daddr="
                        var ipAddr = Utility.LongToIpAddress(logToMonitor.Substring(firstIndex+7, lastIndex));
                        var firstIndexp = logToMonitor.IndexOf("sport=\"");
                        var lastIndexp = logToMonitor.Substring(firstIndexp + 7).IndexOf("\"");// 7 is length sport="
                        var sport = logToMonitor.Substring(firstIndexp + 7, lastIndexp).Replace("-", "");
                        if (NetConfigList.IpToWatches.FirstOrDefault(x => ipAddr.Contains(x.IpAddress)) != null || NetConfigList.PortToWatches.FirstOrDefault(x => sport.Contains(x.Port)) != null)
                        {
                            Console.WriteLine(logToMonitor);
                            _xml.LoadXml(logToMonitor.Replace("/>", " Time=\"" + data.TimeStamp + "\" />"));
                            var xdFile = JsonConvert.SerializeXmlNode(_xml);
                            ConqueEvent.Enqueue(xdFile);
                        }
                    }
                   
                }
                else
                {
                    var log = new StringBuilder(logToMonitor);
                    Console.WriteLine(logToMonitor);
                    int i = lg.IndexOf("PID", StringComparison.Ordinal);
                    int j = lg.LastIndexOf("PID", StringComparison.Ordinal);
                    if (i != j)
                    {
                        log = log.Remove(j, 3).Insert(j, "PIDD");
                    }
                    
                    _xml.LoadXml(log.ToString().Replace("/>", " Time=\"" + data.TimeStamp + "\" />"));
                    var xd = JsonConvert.SerializeXmlNode(_xml);
                    ConqueEvent.Enqueue(xd);
                }
               
            };
            if (Operation == 4)//if user choose file event use different session
            {
                //session.EnableProvider(fileProviderGuid, TraceEventLevel.Informational, 0x100);
                using (var kernelSession = new TraceEventSession(KernelTraceEventParser.KernelSessionName, null))
                {
                    using (var kernelSource = new ETWTraceEventSource(KernelTraceEventParser.KernelSessionName, TraceEventSourceType.Session))
                    {

                        var kernelParser = new KernelTraceEventParser(kernelSource);
                        kernelSession.StopOnDispose = true;
                        kernelSession.EnableKernelProvider(
                            //KernelTraceEventParser.Keywords.NetworkTCPIP
                          //  KernelTraceEventParser.Keywords.Process |
                            //KernelTraceEventParser.Keywords.Registry
                            KernelTraceEventParser.Keywords.DiskFileIO |
                            KernelTraceEventParser.Keywords.FileIOInit |
                            KernelTraceEventParser.Keywords.Thread |
                            KernelTraceEventParser.Keywords.FileIO
                            );
                        kernelParser.All += logAction;
                        kernelSource.Process();
                    }

                }
            }
            else
            {
                using (var session = new TraceEventSession(sessionName, null))
                {

                    session.StopOnDispose = true;
                    using (var source = new ETWTraceEventSource(sessionName, TraceEventSourceType.Session))
                    {
                        var registerParser = new RegisteredTraceEventParser(source);
                        registerParser.All += logAction;
                        var processProviderGuid = TraceEventSession.GetProviderByName("Microsoft-Windows-Kernel-Process");
                        var registryProviderGuid = TraceEventSession.GetProviderByName("Microsoft-Windows-Kernel-Registry");
                        var networkProviderGuid = TraceEventSession.GetProviderByName("Microsoft-Windows-Kernel-Network");
                        var fileProviderGuid = TraceEventSession.GetProviderByName("Microsoft-Windows-Kernel-File");
                        if (processProviderGuid == Guid.Empty)
                        {
                            Console.WriteLine("Error could not find Microsoft-Windows-Kernel-Process etw provider.");
                        }
                        switch (Operation)
                        {
                            case 1:
                                {
                                    session.EnableProvider(processProviderGuid, TraceEventLevel.Informational, 0x10);
                                    source.Process();
                                    break;
                                }
                            case 2:
                                {
                                    session.EnableProvider(registryProviderGuid, TraceEventLevel.Informational, 0x02100);
                                    source.Process();
                                    break;
                                }
                            case 3:
                                {
                                    session.EnableProvider(networkProviderGuid, TraceEventLevel.Informational, 0x10);
                                    source.Process();
                                    break;
                                }
                        }

                        //session.EnableProvider(registryProviderGuid, TraceEventLevel.Informational, 0x02100);
                        // session.EnableProvider(networkProviderGuid, TraceEventLevel.Informational, 0x10);
                        // session.EnableProvider(fileProviderGuid, TraceEventLevel.Informational, 0x0200);

                    }
                }
            }
          
            
        }
    }
}
