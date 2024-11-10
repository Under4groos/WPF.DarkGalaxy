using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WPF.DarkGalaxy.Helper.Enums;
using WPF.DarkGalaxy.Helper.Structures;

namespace WPF.DarkGalaxy.Helper
{
    public static class Native
    {
        [DllImport("user32.dll")]
        public static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false , SetLastError = true)]
        private static extern long DwmSetWindowAttribute(IntPtr hwnd,
            DWMWINDOWATTRIBUTE attribute,
            ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
            uint cbAttribute);
        public static long DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE attribute)
        {
            var preference = DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            return DwmSetWindowAttribute(hwnd,attribute,ref preference,sizeof(uint));
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, Int32 flags);


        [DllImport("user32.dll")]
        public static extern Boolean GetMonitorInfo(IntPtr hMonitor, NativeMonitorInfo lpmi);


    }
}
