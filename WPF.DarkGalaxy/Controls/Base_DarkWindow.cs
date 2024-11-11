using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WPF.DarkGalaxy.Controls
{
    public class Base_DarkWindow : System.Windows.Window
    {

        #region PARTS
        protected const string PART_MaxButton = "PART_MaxButton";
        protected const string PART_MinButton = "PART_MinButton";
        protected const string PART_RestoreButton = "PART_RestoreButton";
        protected const string PART_CloseButton = "PART_CloseButton";
        protected const string PART_BackgroundImage = "PART_BackgroundImage";
        protected const string PART_LeftItems = "PART_LeftItems";
        protected const string PART_RightItems = "PART_RightItems";
        protected const string PART_BackgroundBlur = "PART_BackgroundBlur";
        protected const string PART_WindowBackground = "PART_WindowBackground"; 
        #endregion


        protected Button btnMax;
        protected Button btnMin;
        protected Button btnRestore;
        protected Button btnClose;
        protected IntPtr _HANDLE = IntPtr.Zero;

        public IntPtr HANDLE
        {
            get
            {
                if (_HANDLE == IntPtr.Zero)
                    _HANDLE = new WindowInteropHelper(this).Handle;
                return _HANDLE;
            }
        }

        public virtual void OnLoadedWindow(object sender, RoutedEventArgs e)
        {

        }
        public Base_DarkWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.Loaded += OnLoadedWindow;
        }
    }
}
