namespace MusicStreamer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbPlayingNow = new System.Windows.Forms.Label();
            this.lbConnections = new System.Windows.Forms.Label();
            this.lbCurrentTrack = new System.Windows.Forms.Label();
            this.lbConnectionsCount = new System.Windows.Forms.Label();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chArtist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbTracksQueue = new System.Windows.Forms.ListBox();
            this.lbTrackQueue = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.fbdOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPlayingNow
            // 
            this.lbPlayingNow.AutoSize = true;
            this.lbPlayingNow.Location = new System.Drawing.Point(12, 9);
            this.lbPlayingNow.Name = "lbPlayingNow";
            this.lbPlayingNow.Size = new System.Drawing.Size(97, 20);
            this.lbPlayingNow.TabIndex = 0;
            this.lbPlayingNow.Text = "Now playing:";
            // 
            // lbConnections
            // 
            this.lbConnections.AutoSize = true;
            this.lbConnections.Location = new System.Drawing.Point(12, 50);
            this.lbConnections.Name = "lbConnections";
            this.lbConnections.Size = new System.Drawing.Size(106, 20);
            this.lbConnections.TabIndex = 1;
            this.lbConnections.Text = "Connections: ";
            // 
            // lbCurrentTrack
            // 
            this.lbCurrentTrack.AutoSize = true;
            this.lbCurrentTrack.Location = new System.Drawing.Point(145, 9);
            this.lbCurrentTrack.Name = "lbCurrentTrack";
            this.lbCurrentTrack.Size = new System.Drawing.Size(19, 20);
            this.lbCurrentTrack.TabIndex = 2;
            this.lbCurrentTrack.Text = "--";
            // 
            // lbConnectionsCount
            // 
            this.lbConnectionsCount.AutoSize = true;
            this.lbConnectionsCount.Location = new System.Drawing.Point(145, 50);
            this.lbConnectionsCount.Name = "lbConnectionsCount";
            this.lbConnectionsCount.Size = new System.Drawing.Size(19, 20);
            this.lbConnectionsCount.TabIndex = 3;
            this.lbConnectionsCount.Text = "--";
            // 
            // lvFiles
            // 
            this.lvFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chArtist,
            this.chFile});
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(394, 93);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(818, 347);
            this.lvFiles.TabIndex = 5;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.DoubleClick += new System.EventHandler(this.LvFiles_DoubleClick);
            this.lvFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvFiles_MouseClick);
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 210;
            // 
            // chArtist
            // 
            this.chArtist.Text = "Artist";
            this.chArtist.Width = 126;
            // 
            // chFile
            // 
            this.chFile.Text = "File";
            this.chFile.Width = 121;
            // 
            // lbTracksQueue
            // 
            this.lbTracksQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTracksQueue.FormattingEnabled = true;
            this.lbTracksQueue.ItemHeight = 20;
            this.lbTracksQueue.Items.AddRange(new object[] {
            " "});
            this.lbTracksQueue.Location = new System.Drawing.Point(16, 138);
            this.lbTracksQueue.Name = "lbTracksQueue";
            this.lbTracksQueue.Size = new System.Drawing.Size(372, 302);
            this.lbTracksQueue.TabIndex = 6;
            // 
            // lbTrackQueue
            // 
            this.lbTrackQueue.AutoSize = true;
            this.lbTrackQueue.Location = new System.Drawing.Point(12, 102);
            this.lbTrackQueue.Name = "lbTrackQueue";
            this.lbTrackQueue.Size = new System.Drawing.Size(112, 20);
            this.lbTrackQueue.TabIndex = 7;
            this.lbTrackQueue.Text = "Tracks Queue:";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.GhostWhite;
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpen.Location = new System.Drawing.Point(1025, 9);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(187, 61);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Open Music Directory";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.BackColor = System.Drawing.Color.GhostWhite;
            this.btnClearQueue.Location = new System.Drawing.Point(271, 93);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(117, 39);
            this.btnClearQueue.TabIndex = 9;
            this.btnClearQueue.Text = "Clear queue";
            this.btnClearQueue.UseVisualStyleBackColor = false;
            this.btnClearQueue.Click += new System.EventHandler(this.BtnClearQueue_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1226, 451);
            this.Controls.Add(this.btnClearQueue);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lbTrackQueue);
            this.Controls.Add(this.lbTracksQueue);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.lbConnectionsCount);
            this.Controls.Add(this.lbCurrentTrack);
            this.Controls.Add(this.lbConnections);
            this.Controls.Add(this.lbPlayingNow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Music Streamer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPlayingNow;
        private System.Windows.Forms.Label lbConnections;
        private System.Windows.Forms.Label lbCurrentTrack;
        private System.Windows.Forms.Label lbConnectionsCount;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ListBox lbTracksQueue;
        private System.Windows.Forms.Label lbTrackQueue;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chArtist;
        private System.Windows.Forms.ColumnHeader chFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.FolderBrowserDialog fbdOpen;
        private System.Windows.Forms.Button btnClearQueue;
    }
}

