using Discord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiobeLabBot.Logging
{
    internal class Logger : StreamWriter
    {
        private static readonly object locker = new();
        public Logger(string path, bool append) : base(path, append) { }

        public override void Write(string? value)
        {
            lock (locker)
            {
                if (value != Environment.NewLine)
                {
                    value = $"{DateTime.Now:yyy/MM/dd HH:mm:ss}: {value}{Environment.NewLine}";
                    base.Write(value);
                }
            }
        }

        public static async Task Log(LogMessage message)
        {
            Console.WriteLine(message);
        }
    }
}
