using System.Runtime.InteropServices;
using WPF.DarkGalaxy.Helper.Enums;

namespace WPF.DarkGalaxy.Helper.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AccentPolicy
    {
        public AccentState AccentState;
        public uint AccentFlags;
        public uint GradientColor;
        public uint AnimationId;
    }
}
