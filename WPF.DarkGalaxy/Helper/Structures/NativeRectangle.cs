using System.Runtime.InteropServices;

namespace WPF.DarkGalaxy.Helper.Structures
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct NativeRectangle
    {
        public Int32 Left;
        public Int32 Top;
        public Int32 Right;
        public Int32 Bottom;



        public NativeRectangle(Int32 left, Int32 top, Int32 right, Int32 bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }
    }
}
