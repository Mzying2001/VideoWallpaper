using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                if (CheckStarted())
                    throw new Exception("程序已启动");

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

                SystemEvents.SessionSwitch += (s, e) =>
                {
                    if (e.Reason == SessionSwitchReason.SessionUnlock)
                        wf.VideoUrl = wf.VideoUrl;
                };

                wf.FormClosing += (s, e) => DllImports.ShowWindow(hWorkerW, 0);
                wf.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool CheckStarted()
        {
            Process cur = Process.GetCurrentProcess();
            return (from p in Process.GetProcesses() where p.ProcessName == cur.ProcessName && p.Id != cur.Id select p).Any();
        }
    }
}
