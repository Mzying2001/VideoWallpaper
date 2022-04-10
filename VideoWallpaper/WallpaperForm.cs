using System;
using System.Reflection;
using System.Windows.Forms;

namespace VideoWallpaper
{
    public partial class WallpaperForm : Form
    {
        public string VideoUrl
        {
            get { return mediaPlayer.URL; }
            set
            {
                mediaPlayer.URL = value;
                mediaPlayer.stretchToFit = true;
                mediaPlayer.settings.mute = true;
            }
        }

        public WallpaperForm()
        {
            InitializeComponent();
        }

        private void WallpaperWindow_Load(object sender, EventArgs e)
        {
            if (VideoWallpaper.GetSavedVideoUrl() is string videoUrl)
            {
                VideoUrl = videoUrl;
            }
            else
            {
                if (!SelectVideo())
                {
                    Application.Exit();
                    return;
                }
            }

            Top = 0;
            Left = 0;
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            mediaPlayer.uiMode = "none";
            mediaPlayer.settings.setMode("loop", true);
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
                VideoWallpaper.SaveVideoUrl(VideoUrl);
                return true;
            }
            return false;
        }

        public void Reload()
        {
            Invoke(new Action(() =>
            {
                VideoUrl = VideoUrl;
                mediaPlayer.Ctlcontrols.play();
            }));
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var t = notifyIcon.GetType();
                t.GetMethod("ShowContextMenu", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(notifyIcon, null);
            }
        }

        private void NotifyIconContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuItem_AutoStartUp.Checked = VideoWallpaper.AutoStartUp;
        }

        private void MenuItem_AutoStartUp_Click(object sender, EventArgs e)
        {
            VideoWallpaper.AutoStartUp = !VideoWallpaper.AutoStartUp;
        }

        private void MenuItem_ChangeVideo_Click(object sender, EventArgs e)
        {
            SelectVideo();
        }

        private void MenuItem_CloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
