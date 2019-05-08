using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class HashClass
    {
        public static string GetHashFile(string filePath, HashAlgorithm hasher)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var bfs = new BufferedStream(fs))
                    {
                        var hash = hasher.ComputeHash(bfs);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
            


        }

        public static bool IsValidHashProcess(string hashString)
        {
            var result = HashFileListClass.HashList.FirstOrDefault(x => String.CompareOrdinal(x.Hash, hashString) == 0)!=null;
            return result;
        }

        private static readonly List<string> _unPermittedProcess = new List<string>();

        public static List<string> UnPermittedProcess
        {
            set { _unPermittedProcess.AddRange(value); }
            get
            {
                if (_unPermittedProcess != null)
                    return _unPermittedProcess;
                return new List<string>();
            }
        }
    }
}
