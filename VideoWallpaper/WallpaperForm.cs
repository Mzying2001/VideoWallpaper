using System;
using System.IO;
using System.Windows.Forms;

namespace VideoWallpaper
{
    public partial class WallpaperForm : Form
    {
        public string VideoUrl
        {
            get { return axWindowsMediaPlayer1.URL; }
            set
            {
                axWindowsMediaPlayer1.URL = value;
                axWindowsMediaPlayer1.stretchToFit = true;
                axWindowsMediaPlayer1.settings.mute = true;
            }
        }



        public WallpaperForm()
        {
            InitializeComponent();
        }

        private void WallpaperWindow_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VideoUrl) || !File.Exists(VideoUrl))
            {
                if (!SelectVideo()) Close();
            }

            Top = 0;
            Left = 0;
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private bool SelectVideo()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "选择视频文件"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                VideoUrl = ofd.FileName;
                File.WriteAllText(VideoWallpaper.VIDEO_TXT, ofd.FileName);
                return true;
            }
            return false;
        }

        public void Reload()
        {
            VideoUrl = VideoUrl;
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        }

        private void MenuItem_ChangeVideo_Click(object sender, EventArgs e)
        {
            SelectVideo();
        }

        private void MenuItem_CloseWindow_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItem_CloseMenu_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Visible = false;
        }
    }
}
