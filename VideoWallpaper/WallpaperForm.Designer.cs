namespace VideoWallpaper
{
    partial class WallpaperForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WallpaperForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_ChangeVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_AutoStartUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_CloseWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "VideoWallpaper";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_ChangeVideo,
            this.toolStripSeparator1,
            this.MenuItem_AutoStartUp,
            this.MenuItem_CloseWindow});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 82);
            // 
            // MenuItem_ChangeVideo
            // 
            this.MenuItem_ChangeVideo.Name = "MenuItem_ChangeVideo";
            this.MenuItem_ChangeVideo.Size = new System.Drawing.Size(138, 24);
            this.MenuItem_ChangeVideo.Text = "更换视频";
            this.MenuItem_ChangeVideo.Click += new System.EventHandler(this.MenuItem_ChangeVideo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // MenuItem_AutoStartUp
            // 
            this.MenuItem_AutoStartUp.Name = "MenuItem_AutoStartUp";
            this.MenuItem_AutoStartUp.Size = new System.Drawing.Size(138, 24);
            this.MenuItem_AutoStartUp.Text = "开机自启";
            this.MenuItem_AutoStartUp.Click += new System.EventHandler(this.MenuItem_AutoStartUp_Click);
            // 
            // MenuItem_CloseWindow
            // 
            this.MenuItem_CloseWindow.Name = "MenuItem_CloseWindow";
            this.MenuItem_CloseWindow.Size = new System.Drawing.Size(138, 24);
            this.MenuItem_CloseWindow.Text = "退出程序";
            this.MenuItem_CloseWindow.Click += new System.EventHandler(this.MenuItem_CloseWindow_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(500, 300);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // WallpaperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WallpaperForm";
            this.Text = "WallpaperWindow";
            this.Load += new System.EventHandler(this.WallpaperWindow_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_CloseWindow;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_ChangeVideo;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_AutoStartUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}