using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    class ConsoleLogger : ILogger
    {
        public void LogMessage(string msg)
        {
            Console.WriteLine($"{DateTime.Now}: {msg}");
        }
    }
}
