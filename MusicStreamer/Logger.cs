//
//   Logger - класс для сбора ошибок программы
//
//
//

using System;
using System.IO;
using System.Text;

namespace MusicStreamer
{
    public static class Logger
    {
        const string LogFile = "logs.txt";

        public static void SetError(string error)
        {
            using (StreamWriter streamWriter = new StreamWriter(LogFile, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(DateTime.Now.ToString() + ":" + error);
            }
        }
    }
}
