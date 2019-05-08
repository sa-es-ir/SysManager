using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Utility
    {
        static readonly ManagementObjectSearcher searcher = new ManagementObjectSearcher();
        static ManagementObjectCollection _collection;
        static readonly ObjectQuery q = new ObjectQuery();
        public static string GetExecutePath(int processId)
        {
            try
            {
                if (processId != 0) //Idle process dont have path
                {
                    q.QueryString = "Select ExecutablePath from  Win32_Process Where ProcessId=" + processId;
                    searcher.Query = q;
                    _collection = searcher.Get();
                    return
                        (from ManagementBaseObject item in _collection select item["ExecutablePath"].ToString())
                            .FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public static string LongToIpAddress(string ipLong)
        {
            var addr = string.Empty;
            try
            {
                long longIp = 0;
                long.TryParse(ipLong, out longIp);
                longIp = longIp < 0 ? longIp*-1 : longIp;
                addr = new IPAddress(longIp).ToString();
            }
            catch
            {
                addr = "255.255.255.255";
            }
            return addr;
        }

        public static string IpAddressToLong(string ip)
        {
            try
            {
                var ipLong = IPAddress.Parse(ip).Address;
                return ipLong.ToString();
            }
            catch
            {
                return "00000000";
            }
          
        }

        #region Define DllImport
        [DllImport("kernel32.dll")]
        static extern uint GetFileSize(IntPtr hFile, IntPtr lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFileMapping(
            IntPtr hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            [MarshalAs(UnmanagedType.LPTStr)]string lpName);

        [Flags]
        public enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr MapViewOfFile(
            IntPtr hFileMappingObject,
            FileMapAccess dwDesiredAccess,
            uint dwFileOffsetHigh,
            uint dwFileOffsetLow,
            uint dwNumberOfBytesToMap);

        [Flags]
        public enum FileMapAccess : uint
        {
            FileMapCopy = 0x0001,
            FileMapWrite = 0x0002,
            FileMapRead = 0x0004,
            FileMapAllAccess = 0x001f,
            fileMapExecute = 0x0020,
        }

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern uint GetMappedFileName(IntPtr m_hProcess, IntPtr lpv, StringBuilder
                lpFilename, uint nSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);
        #endregion
        public static string GetFileNameFromHandle(IntPtr fileHandle)
        {
            string fileName = String.Empty;
            IntPtr fileMap = IntPtr.Zero, fileSizeHi = IntPtr.Zero;
            UInt32 fileSizeLo = 0;

            fileSizeLo = GetFileSize(fileHandle, fileSizeHi);

            if (fileSizeLo == 0)
            {
                // cannot map an 0 byte file
                return "Empty file.";
            }

            fileMap = CreateFileMapping(fileHandle, IntPtr.Zero, FileMapProtection.PageReadonly, 0, 1, null);

            if (fileMap != IntPtr.Zero)
            {
                IntPtr pMem = MapViewOfFile(fileMap, FileMapAccess.FileMapRead, 0, 0, 1);
                if (pMem != IntPtr.Zero)
                {
                    StringBuilder fn = new StringBuilder(250);
                    GetMappedFileName(System.Diagnostics.Process.GetCurrentProcess().Handle, pMem, fn, 250);
                    if (fn.Length > 0)
                    {
                        UnmapViewOfFile(pMem);
                        CloseHandle(fileHandle);
                        return fn.ToString();
                    }
                    else
                    {
                        UnmapViewOfFile(pMem);
                        CloseHandle(fileHandle);
                        return "Empty filename.";
                    }
                }
            }

            return "Empty filemap handle.";
        }
    }
}
