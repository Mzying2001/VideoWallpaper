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
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_ChangeVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem_AutoStartUp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_CloseWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.notifyIconContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "VideoWallpaper";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // notifyIconContextMenu
            // 
            this.notifyIconContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_ChangeVideo,
            this.toolStripSeparator1,
            this.menuItem_AutoStartUp,
            this.menuItem_CloseWindow});
            this.notifyIconContextMenu.Name = "contextMenuStrip1";
            this.notifyIconContextMenu.Size = new System.Drawing.Size(139, 82);
            this.notifyIconContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.NotifyIconContextMenu_Opening);
            // 
            // menuItem_ChangeVideo
            // 
            this.menuItem_ChangeVideo.Name = "menuItem_ChangeVideo";
            this.menuItem_ChangeVideo.Size = new System.Drawing.Size(138, 24);
            this.menuItem_ChangeVideo.Text = "更换视频";
            this.menuItem_ChangeVideo.Click += new System.EventHandler(this.MenuItem_ChangeVideo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // menuItem_AutoStartUp
            // 
            this.menuItem_AutoStartUp.Name = "menuItem_AutoStartUp";
            this.menuItem_AutoStartUp.Size = new System.Drawing.Size(138, 24);
            this.menuItem_AutoStartUp.Text = "开机自启";
            this.menuItem_AutoStartUp.Click += new System.EventHandler(this.MenuItem_AutoStartUp_Click);
            // 
            // menuItem_CloseWindow
            // 
            this.menuItem_CloseWindow.Name = "menuItem_CloseWindow";
            this.menuItem_CloseWindow.Size = new System.Drawing.Size(138, 24);
            this.menuItem_CloseWindow.Text = "退出程序";
            this.menuItem_CloseWindow.Click += new System.EventHandler(this.MenuItem_CloseWindow_Click);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(500, 300);
            this.mediaPlayer.TabIndex = 0;
            // 
            // WallpaperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.mediaPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WallpaperForm";
            this.Text = "WallpaperWindow";
            this.Load += new System.EventHandler(this.WallpaperWindow_Load);
            this.notifyIconContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItem_CloseWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItem_ChangeVideo;
        private System.Windows.Forms.ToolStripMenuItem menuItem_AutoStartUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}