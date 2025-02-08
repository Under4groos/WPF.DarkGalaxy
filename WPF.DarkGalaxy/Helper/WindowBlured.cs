using System.Runtime.InteropServices;
using WPF.DarkGalaxy.Helper.Enums;
using WPF.DarkGalaxy.Helper.Structures;

namespace WPF.DarkGalaxy.Helper
{
    public static class WindowBlured
    {
        public static void Blur(AccentState accentState, IntPtr hwnd, bool status)
        {
            var accent = new AccentPolicy();
            if (status)
            {
                accent.AccentState = accentState;
            }
            else
            {
                accent.AccentState = AccentState.ACCENT_DISABLED;
            }
            accent.GradientColor = 0x273130;// 0xFFFFFF;
            var accentStructSize = Marshal.SizeOf(accent);
            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);
            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;
            Native.SetWindowCompositionAttribute(hwnd, ref data);
            Marshal.FreeHGlobal(accentPtr);
        }
    }
}
