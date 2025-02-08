using System.Windows;
using WPF.DarkGalaxy.Helper.Enums;
using WPF.DarkGalaxy.Helper.Structures;
namespace WPF.DarkGalaxy.Helper
{
    public static class NativeMonitors
    {


        public static bool MonitorFromWindow(IntPtr handle, ref NativeMonitorInfo monitorInfo, ref Size SizeScreen)
        {
            if (handle == IntPtr.Zero)
                return false;
            var monitor = Helper.Native.MonitorFromWindow(handle, (int)MONITOR_DEFAULT.MONITOR_DEFAULTTONEAREST);
            if (monitor == IntPtr.Zero)
                return false;


            Helper.Native.GetMonitorInfo(monitor, monitorInfo);


            var width = (monitorInfo.Monitor.Right - monitorInfo.Monitor.Left);
            var height = (monitorInfo.Monitor.Bottom - monitorInfo.Monitor.Top);


            SizeScreen.Width = width;
            SizeScreen.Height = height;
            //SizeScreen = new System.Windows.Size(width, height);



            return true;
        }
    }
}
