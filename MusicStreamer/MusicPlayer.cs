using NAudio.Wave;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

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
            PlayerThread = new Thread(new ThreadStart(Player));
            PlayerThread.Start();
        }

        public void ClearQueue()
        {
            MusicFile musicFile;
            while (!Queue.IsEmpty)
            {
                Queue.TryDequeue(out musicFile);
            }
            if (OnFileListUpdate != null) OnFileListUpdate.Invoke(Queue.ToList());
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

        void Player()
        {
            MusicFile file;
            while (IsActive)
            {
                do
                {
                    Queue.TryDequeue(out file);
                    if (!IsActive) return;
                } while (file == null);
                if (OnFileListUpdate != null) OnFileListUpdate.Invoke(Queue.ToList());
                Mp3Frame frame = null;
                try
                {
                    file.Open();
                    frame = file.GetFrame();
                }
                catch (Exception)
                {
                    Logger.SetError(string.Format("MusicPlayer error: 'can't decode file [{0}]'", file.Filename));
                }
                while (frame != null)
                {
                    foreach (Stream output in OutputStreams.Keys)
                    {
                        try
                        {
                            output.WriteAsync(frame.RawData, 0, frame.RawData.Length);
                            output.FlushAsync();
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
