using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStreamer
{
    public static class Logger
    {
        const string LogFile = "logs.txt";

        public static void SetError(string error)
        {
            using (StreamWriter streamWriter = new StreamWriter(LogFile, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(DateTime.Now.ToString()+ ":" + error);
            }
        }
    }
}
