using System;
using System.IO;
using System.Windows.Forms;

namespace VideoWallpaper
{
    public class VideoWallpaper
    {
        public const string VIDEO_TXT = "./video.txt";

        [STAThread]
        public static void Main()
        {
            try
            {
                IntPtr hProgman = DllImports.FindWindow("Progman", null);
                DllImports.SendMessageTimeout(hProgman, 0x52c, 0, 0, 0, 100, out _);

                IntPtr hWorkerW = default;
                DllImports.EnumWindows((hwnd, lParam) =>
                {
                    IntPtr hDefView = DllImports.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null);
                    if (hDefView == IntPtr.Zero) return true;

                    hWorkerW = DllImports.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                    DllImports.ShowWindow(hWorkerW, 5);
                    return false;
                }, 0);

                string videoUrl = null;
                if (File.Exists(VIDEO_TXT))
                    videoUrl = File.ReadAllText(VIDEO_TXT);

                WallpaperForm wf = new WallpaperForm { VideoUrl = videoUrl };
                DllImports.SetParent(wf.Handle, hWorkerW);

                wf.FormClosing += (s, e) => DllImports.ShowWindow(hWorkerW, 0);
                wf.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
