using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VideoWallpaper
{
    public partial class WallpaperForm : Form
    {
        private static readonly string AutoStartUpLnkPath
            = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "VideoWallpaperAutoStartUp.lnk");

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

        public bool AutoStartUp
        {
            get { return File.Exists(AutoStartUpLnkPath); }
            set
            {
                if (value)
                {
                    var shell = new IWshRuntimeLibrary.WshShell();
                    var shortcut = (IWshRuntimeLibrary.WshShortcut)shell.CreateShortcut(AutoStartUpLnkPath);
                    shortcut.TargetPath = Application.ExecutablePath;
                    shortcut.WorkingDirectory = Environment.CurrentDirectory;
                    shortcut.Save();
                }
                else
                {
                    if (File.Exists(AutoStartUpLnkPath))
                        File.Delete(AutoStartUpLnkPath);
                }
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

            MenuItem_AutoStartUp.Checked = AutoStartUp;
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
            Invoke(new Action(() =>
            {
                VideoUrl = VideoUrl;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }));
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var t = notifyIcon1.GetType();
                t.GetMethod("ShowContextMenu", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(notifyIcon1, null);
            }
        }

        private void MenuItem_AutoStartUp_Click(object sender, EventArgs e)
        {
            AutoStartUp = !AutoStartUp;
            MenuItem_AutoStartUp.Checked = AutoStartUp;
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
