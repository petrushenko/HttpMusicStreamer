//
//   MusicFile - класс для работы с метаданными аудио
//
//
//

using NAudio.Wave;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using TagLib;

namespace MusicStreamer
{
    class MusicFile
    {
        Mp3FileReader Reader;

        public string Filename;
        private long Duration;
        private File File; //get music file metadata
        private Stopwatch Stopwatch;

        public MusicFile(string filename)
        {
            Filename = filename;
            File = File.Create(filename);
        }

        public string Title
        {
            get { return File.Tag.Title; }
            set { File.Tag.Title = value; }
        }
        public string Artist => File.Tag.FirstPerformer;

        public void Open()
        {
            Stopwatch = new Stopwatch();
            Reader = new Mp3FileReader(Filename);
            Duration = 0;
            Stopwatch.Start();
        }

        public Mp3Frame GetFrame()
        {
            while (Stopwatch.ElapsedMilliseconds < Duration)
            {
                Thread.Sleep(1);
            }
            var frame = Reader.ReadNextFrame();
            if (frame == null) return frame;
            Duration += FrameDuration(frame);
            return frame;
        }

        private long FrameDuration(Mp3Frame frame)
        {
            var byterate = frame.BitRate / 8;
            return frame.FrameLength * 1000 / byterate;
        }

        public override string ToString()
        {
            if (Title != null && Title != "") return Title;
            var res = new Regex(@"/|\\(.*)\.mp3").Match(Filename);
            return res.Captures[0].Value;
        }
    }
}
