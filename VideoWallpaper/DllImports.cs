using System;
using System.Runtime.InteropServices;
using System.Text;

namespace VideoWallpaper
{
    public static class DllImports
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, int uMsg, int wParam, int lParam, int fuFlags, int uTimeout, out StringBuilder lpdwResult);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    }
}
