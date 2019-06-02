using System;
using System.Net;
using System.Text;
using System.Threading;

namespace MusicStreamer
{
    class Streamer : IDisposable
    {
        //private bool IsDisposed { get; set; }
        private bool IsWaiting { get; set; }
        public MusicPlayer Player;
        private readonly HttpListener Listener;
        private Thread WaitingForConnectionsThread { get; set; }

        public Streamer(int port)
        {
            Player = new MusicPlayer();
            Player.Start();

            Listener = new HttpListener();
            Listener.Prefixes.Add("http://+:" + port + "/");
            Listener.Start();
            IsWaiting = true;
            WaitingForConnectionsThread = new Thread(WaitForConnections);
            WaitingForConnectionsThread.Start();
        }

        private void WaitForConnections()
        {
            while (IsWaiting)
            {
                try
                {
                    Console.WriteLine("New connection!");
                    HttpListenerContext context = Listener.GetContext();
                    Process(context);
                }
                catch (Exception)
                {
                    Console.WriteLine("Stop listening");
                }
            }
        }

        void Process(object o)
        {
            var context = o as HttpListenerContext;
            HttpListenerRequest req = context.Request;
            HttpListenerResponse res = context.Response;
            if (req.HttpMethod == "GET")
            {
                if (req.RawUrl != "/stream")
                {
                    string responseString = "<HTML><BODY> Stream is available at /stream </BODY></HTML>";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    res.ContentLength64 = buffer.Length;
                    res.OutputStream.Write(buffer, 0, buffer.Length);
                }
                else
                {
                    res.AddHeader("content-type", "audio/mpeg");
                    Player.Attach(res.OutputStream);
                }
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Listener.Stop();
                Listener.Close();
            }
            Player.IsActive = false;
            IsWaiting = false;
        }

        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);            
        }
    }
}
