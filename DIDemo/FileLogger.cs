using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    class FileLogger : ILogger
    {
        public void LogMessage(string msg)
        {
            File.AppendAllText(@"c:\tmp\mylog.txt", $"{DateTime.Now}: {msg}");

        }
    }
}
