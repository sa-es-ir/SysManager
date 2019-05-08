using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Common
{
    public static class PipLineManager
    {
        public static ConcurrentDictionary<string,int> FileAccessCount=new ConcurrentDictionary<string, int>();
        public static ConcurrentDictionary<string, string> AccessRegitryPathForOneProcess = new ConcurrentDictionary<string, string>();
        public static ConcurrentQueue<string> BlockRegistryPath = new ConcurrentQueue<string>(
            new List<string>() { "Run", "Policies", "Policy" });
        public static ConcurrentQueue<string> SaveDirectory = new ConcurrentQueue<string>(
            new List<string>() { @"E:\EventLogInCS\" });
        public static ConcurrentQueue<string> BlockProcess = new ConcurrentQueue<string>(
            new List<string>() { "dev" });
        public static ConcurrentQueue<string> ProcessUseNetwork = new ConcurrentQueue<string>(
            new List<string>() { "everything", "chrome" }); 
        public static ConcurrentDictionary<string,string> ProcessDictionary=new ConcurrentDictionary<string, string>();  
        public static ConcurrentQueue<NetworkEvent> NetworkUsage=new ConcurrentQueue<NetworkEvent>();
        public static ConcurrentDictionary<string,NetworkEvent> netU=new ConcurrentDictionary<string, NetworkEvent>(); 
        public static ConcurrentQueue<RegistryEvent> RegistryUsage=new ConcurrentQueue<RegistryEvent>(); 
        public static ConcurrentQueue<FileEvent> FileEvents=new ConcurrentQueue<FileEvent>();
        public static int operation = 1;

        public static Semaphore _sem=new Semaphore(1,1);
        public static string ReadFile()
        {
            string content = "";
            _sem.WaitOne();
            content = File.ReadAllText(ConfigurationManager.AppSettings["FileLocationInfo"]);
            File.WriteAllText(ConfigurationManager.AppSettings["FileLocationInfo"], "");
            _sem.Release();
            return content;
        }

        public static void WriteFile(string txt)
        {
            _sem.WaitOne();
             File.WriteAllText(ConfigurationManager.AppSettings["FileLocationInfo"],txt);
            _sem.Release();
        }
    }
}
