using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoWallpaper
{
    public class VideoWallpaper
    {
        public const string VIDEO_TXT = "./video.txt"; //记录视频路径的文件

        private const string ARG_ONRESTART = "-onRestart"; //重启程序时添加此参数以取消对多开的检测

        private static bool restart = false; //是否要重启程序

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                if (!args.Contains(ARG_ONRESTART) && CheckStarted())
                    throw new Exception("程序已启动");

                IntPtr hProgman = DllImports.FindWindow("Progman", null);
                DllImports.SendMessageTimeout(hProgman, 0x52c, 0, 0, 0, 100, out _);

                IntPtr hWorkerW = IntPtr.Zero;
                DllImports.EnumWindows((hwnd, lParam) =>
                {
                    IntPtr hDefView = DllImports.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null);
                    if (hDefView == IntPtr.Zero)
                    {
                        return true;
                    }
                    else
                    {
                        hWorkerW = DllImports.FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                        DllImports.ShowWindow(hWorkerW, 5);
                        return false;
                    }
                }, 0);

                WallpaperForm wf = new WallpaperForm { VideoUrl = GetSavedVideoUrl() };
                DllImports.SetParent(wf.Handle, hWorkerW);

                SystemEvents.SessionSwitch += (s, e) =>
                {
                    //防止屏幕解锁后花屏
                    if (e.Reason == SessionSwitchReason.SessionUnlock)
                        wf.Reload();
                };

                PowerStatusMonitor psm = new PowerStatusMonitor((context, type, setting) =>
                {
                    //防止系统睡眠到唤醒时黑屏
                    if (type == PowerStatusMonitor.PBT_APMRESUMESUSPEND)
                        wf.Reload();
                    return 0;
                });
                psm.Register();

                CancellationTokenSource cts = new CancellationTokenSource();
                Task keepWallpaperTask = KeepWallpaper(hProgman, cts);

                Application.Run(wf);

                psm.UnRegister();
                cts.Cancel();
                if (restart)
                {
                    Process.Start(Application.ExecutablePath, ARG_ONRESTART);
                }
                else
                {
                    DllImports.ShowWindow(hWorkerW, 0);
                }
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

        private static string GetSavedVideoUrl()
        {
            return File.Exists(VIDEO_TXT) ? File.ReadAllText(VIDEO_TXT) : null;
        }

        private static async Task KeepWallpaper(IntPtr hProgman, CancellationTokenSource cts)
        {
            // 实现在资源管理器重启后仍保持动态壁纸：
            // 1、循环检测hProgman是否发生变化
            // 2、当检测到hProgman变化时重启程序

            await Task.Run(async () =>
            {
                while (!cts.IsCancellationRequested)
                {
                    IntPtr hProgmanCurrent = DllImports.FindWindow("Progman", null);
                    if (hProgmanCurrent != IntPtr.Zero && hProgmanCurrent != hProgman)
                    {
                        restart = true;
                        Application.Exit();
                        break;
                    }
                    else
                    {
                        await Task.Delay(200);
                    }
                }
            }, cts.Token);
        }
    }
}
