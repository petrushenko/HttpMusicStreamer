using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MusicStreamer
{
    public partial class MainForm : Form
    {
        private Streamer Streamer { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Streamer = new Streamer(8080);
            Streamer.Player.OnStatusUpdate += Player_OnStatusUpdate;
            Streamer.Player.OnFileListUpdate += Player_OnFileListUpdate;
        }
        private object Player_OnFileListUpdate(List<MusicFile> queue)
        {
            Invoke(new Action(() =>
            {
                lbTracksQueue.DataSource = queue;
            }));
            return null;
        }

        private object Player_OnStatusUpdate(MusicPlayer.MusicPlayerStatus arg)
        {
            try
            {
                Invoke(new Action(() =>
                {
                    lbCurrentTrack.Text = arg.CurrentFile.Title + " - " + arg.CurrentFile.Artist;
                    
                    lbConnectionsCount.Text = string.Format("{0}", arg.Connections);
                }));
            }
            catch (Exception e)
            {
                Logger.SetError(string.Format("Player_OnStatusUpdate error: [{0}]", e.Message));
            }
            return null;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (fbdOpen.ShowDialog() == DialogResult.OK)
            {
                var filenames = Directory.GetFiles(fbdOpen.SelectedPath, "*.mp3");
                foreach (var filename in filenames)
                {
                    var file = new MusicFile(filename);
                    if (file.Title == null)
                    {
                        file.Title = "Unknown";
                    }
                    var item = new ListViewItem(new string[] { file.Title, file.Artist, file.Filename });
                    item.Tag = file;
                    lvFiles.Items.Add(item);
                }
            }
        }

        private void LvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                Streamer.Player.EnqueueMusic((MusicFile)lvFiles.SelectedItems[0].Tag);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Streamer.Dispose();
        }

        private void LvFiles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lvFiles.Items.Remove(lvFiles.SelectedItems[0]);
            }
        }

        private void BtnClearQueue_Click(object sender, EventArgs e)
        {
            Streamer.Player.ClearQueue();
        }
    }
}
