using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace MusicStreamer
{
    class MusicPlayer
    {
        public struct MusicPlayerStatus
        {
            public MusicFile CurrentFile;
            public int Connections;
            public List<MusicFile> Queue;
        }

        public bool IsActive { get; set; }

        public event Func<MusicPlayerStatus, object> OnStatusUpdate;
        public event Func<List<MusicFile>, object> OnFileListUpdate;

        ConcurrentQueue<MusicFile> Queue = new ConcurrentQueue<MusicFile>();
        private Thread PlayerThread { get; set; }
        ConcurrentDictionary<Stream, DateTime> OutputStreams { get; set; }

        public void Start()
        {
            OutputStreams = new ConcurrentDictionary<Stream, DateTime>();
            IsActive = true;
            PlayerThread = new Thread(new ThreadStart(PlayerAsync));
            PlayerThread.Start();
        }

        public void EnqueueMusic(MusicFile file)
        {
            Queue.Enqueue(file);
            if (OnFileListUpdate != null) OnFileListUpdate.Invoke(Queue.ToList());
        }

        public void Attach(Stream outputStream)
        {
            OutputStreams.TryAdd(outputStream, DateTime.Now);
        }

        public void Disattach(Stream outputStream)
        {
            outputStream.Close();
            OutputStreams.TryRemove(outputStream, out DateTime value);
        }

        void PlayerAsync()
        {
            MusicFile file;
            while (IsActive)
            {
                do
                {
                    Queue.TryDequeue(out file);
                    Thread.Sleep(2);
                    if (!IsActive) return;
                } while (file == null);
                if (OnFileListUpdate != null) OnFileListUpdate.Invoke(Queue.ToList());
                file.Open();
                Mp3Frame frame = file.GetFrame();
                while (frame != null)
                {
                    foreach (Stream output in OutputStreams.Keys)
                    {
                        try
                        {
                            output.WriteAsync(frame.RawData, 0, frame.RawData.Length);
                            output.Flush();
                        }
                        catch
                        {
                            output.Close();
                            Disattach(output);
                        }
                    }
                    frame = file.GetFrame();
                    if (!IsActive) return;
                    if (OnStatusUpdate != null)
                    {
                        OnStatusUpdate.Invoke(new MusicPlayerStatus()
                        {
                            CurrentFile = file,
                            Connections = OutputStreams.Count,
                            Queue = Queue.ToList()
                        });
                    }
                }
            }
        }



    }
}
