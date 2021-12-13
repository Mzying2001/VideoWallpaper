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
                DllImports.EnumWindows(EnumWindowsProc_HideWorkerW, 0);

                string videoUrl = null;
                if (File.Exists(VIDEO_TXT))
                    videoUrl = File.ReadAllText(VIDEO_TXT);

                WallpaperForm wf = new WallpaperForm { VideoUrl = videoUrl };
                IntPtr hWf = wf.Handle;
                DllImports.SetParent(hWf, hProgman);

                wf.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool EnumWindowsProc_HideWorkerW(IntPtr hwnd, IntPtr lParam)
        {
            IntPtr hDefView = DllImports.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null);
            if (hDefView == IntPtr.Zero)
                return true;

            IntPtr hWorkerW = DllImports.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
            DllImports.ShowWindow(hWorkerW, 0);
            return false;
        }
    }
}
