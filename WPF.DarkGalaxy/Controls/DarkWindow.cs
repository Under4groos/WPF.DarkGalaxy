using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using WPF.DarkGalaxy.Helper;
using WPF.DarkGalaxy.Helper.Structures;
using WPF.DarkGalaxy.Sys;

namespace WPF.DarkGalaxy.Controls
{
    [TemplatePart(Name = PART_MaxButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_MinButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_RestoreButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_LeftItems, Type = typeof(StackPanel))]
    public class DarkWindow : Base_DarkWindow
    {




        protected ImageBrush imgBackgroundImage;
        protected Border _PART_WindowBackground;
        protected StackPanel LItems;
        protected StackPanel RItems;

        protected BlurEffect blurEffect;


        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));

        }



        #region Binding
        #region OpacityBackground
        public static readonly DependencyProperty OpacityBackgroundProperty = SysDependencyProperty<DarkWindow>.RegisterA(
           nameof(OpacityBackground),
           typeof(double),
           typeof(DarkWindow),
           (o, b) =>
           {
               o.Update_OpacityBackground();
           }
       );
        public double OpacityBackground
        {
            get => (double)GetValue(OpacityBackgroundProperty);
            set => SetValue(OpacityBackgroundProperty, value);
        }
        #endregion
        #region StretchProperty
        public static readonly DependencyProperty StretchProperty = SysDependencyProperty<DarkWindow>.RegisterA(
           nameof(StretchImage),
           typeof(Stretch),
           typeof(DarkWindow),
           (o, b) =>
           {
               o.Update_StretchImageSource();
           }
        );
        public Stretch StretchImage
        {
            get => (Stretch)GetValue(StretchProperty);
            set => SetValue(StretchProperty, value);
        }
        #endregion
        #region BackgroundImageBlured
        public static readonly DependencyProperty BackgroundImageBluredProperty = SysDependencyProperty<DarkWindow>.RegisterA(
           nameof(BackgroundImageBlured),
           typeof(double),
           typeof(DarkWindow),
           (o, b) =>
           {
               o.Update_BackgroundImage();
           }
        );
        public double BackgroundImageBlured
        {
            get => (double)GetValue(BackgroundImageBluredProperty);
            set => SetValue(BackgroundImageBluredProperty, value);
        }
        #endregion
        #region ScreenMargin
        public static readonly DependencyProperty ScreenMarginProperty = SysDependencyProperty<DarkWindow>.RegisterA(
           nameof(ScreenMargin),
           typeof(Size),
           typeof(DarkWindow),
           (o, b) =>
           {
               o.Update_ScreenMargin();
           }
        );
        public Size ScreenMargin
        {
            get => (Size)GetValue(ScreenMarginProperty);
            set => SetValue(ScreenMarginProperty, value);
        }
        #endregion
        #region blured
        public static readonly DependencyProperty IsBlurProperty = SysDependencyProperty<DarkWindow>.RegisterA(
          nameof(IsBlur),
          typeof(bool),
          typeof(DarkWindow),
          (o, b) =>
          {
              o.Update_Blur();
          }
        );
        public bool IsBlur
        {
            get => (bool)GetValue(IsBlurProperty);
            set => SetValue(IsBlurProperty, value);
        }
        #endregion
        #region BackgroundImage
        public static readonly DependencyProperty BackgroundImageProperty = SysDependencyProperty<DarkWindow>.RegisterA(
            nameof(BackgroundImage),
            typeof(string),
            typeof(DarkWindow),
            (o, b) =>
            {
                o.Update_Source();
            }
        );
        public string BackgroundImage
        {
            get => (string)GetValue(BackgroundImageProperty);
            set => SetValue(BackgroundImageProperty, value);
        }
        #endregion
        #region AccentState
        public static readonly DependencyProperty AccentStateProperty = SysDependencyProperty<DarkWindow>.RegisterA(
          nameof(AccentState),
          typeof(Helper.Enums.AccentState),
          typeof(DarkWindow),
          (o, b) =>
          {
              o.Update_AccentState();
          }
        );
        public Helper.Enums.AccentState AccentState
        {
            get => (Helper.Enums.AccentState)GetValue(AccentStateProperty);
            set => SetValue(AccentStateProperty, value);
        }
        #endregion
        #region BackgroundImageOpacity
        public static readonly DependencyProperty BackgroundImageOpacityProperty = SysDependencyProperty<DarkWindow>.RegisterW(
            nameof(BackgroundImageOpacity),
            typeof(double),
            typeof(DarkWindow),
            (double)0.1,
            (o, b) =>
            {
                o.Update_Source();
            }
        );
        public double BackgroundImageOpacity
        {
            get => (double)GetValue(BackgroundImageOpacityProperty);
            set => SetValue(BackgroundImageOpacityProperty, value);
        }
        #endregion
        #endregion


        public override void OnLoadedWindow(object sender, RoutedEventArgs e)
        {
            base.OnLoadedWindow(sender, e);
            this.Update_ScreenMargin();
            this.Update_AccentState();
            this.Update_BackgroundImage();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.btnMax = this.GetTemplateChild(PART_MaxButton) as Button;
            this.btnMin = this.GetTemplateChild(PART_MinButton) as Button;
            this.btnRestore = this.GetTemplateChild(PART_RestoreButton) as Button;
            this.btnClose = this.GetTemplateChild(PART_CloseButton) as Button;
            this.imgBackgroundImage = this.GetTemplateChild(PART_BackgroundImage) as ImageBrush;
            this.LItems = this.GetTemplateChild(PART_LeftItems) as StackPanel;
            this.RItems = this.GetTemplateChild(PART_RightItems) as StackPanel;
            this.blurEffect = this.GetTemplateChild(PART_BackgroundBlur) as BlurEffect;
            this._PART_WindowBackground = this.GetTemplateChild(PART_WindowBackground) as Border;

            this.Update_Source();

            if (this.btnMax != null)
            {
                this.btnMax.Click += btnMax_Click;
            }
            if (this.btnMin != null)
            {
                this.btnMin.Click += btnMin_Click;
            }
            if (this.btnRestore != null)
            {
                this.btnRestore.Click += btnRestore_Click;
            }
            if (this.btnClose != null)
            {
                this.btnClose.Click += btnClose_Click;
            }
        }
        void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
        }
        void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        void btnMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        void Update_ScreenMargin()
        {
            if (this.ScreenMargin.Width == 0 || this.ScreenMargin.Height == 0)
                return;

            NativeMonitorInfo nativeMonitorInfo = new NativeMonitorInfo();
            Size size_window = new Size();
            if (NativeMonitors.MonitorFromWindow(this.HANDLE, ref nativeMonitorInfo, ref size_window))
            {
                double s_w = size_window.Width * this.ScreenMargin.Width;
                double s_h = size_window.Height * this.ScreenMargin.Height;
                this.Width = s_w <= this.MinWidth ? 0 : s_w;
                this.Height = s_h <= this.MinHeight ? 0 : s_h;
            }


        }
        void Update_OpacityBackground()
        {
            if (this.imgBackgroundImage != null)
            {
                this._PART_WindowBackground.Opacity = this.OpacityBackground;
                this.imgBackgroundImage.Opacity = this.BackgroundImageOpacity;
            }

        }
        void Update_BackgroundImage()
        {
            if (this.blurEffect != null)
            {

                this.blurEffect.Radius = this.BackgroundImageBlured;
            }
            if (this.imgBackgroundImage != null && File.Exists(BackgroundImage))
            {
                var bi = new BitmapImage();
                bi.BeginInit();
                bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = new Uri(BackgroundImage, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                this.imgBackgroundImage.ImageSource = bi;
                this.imgBackgroundImage.Stretch = StretchImage;
            }

        }
        void Update_Source()
        {

            this.Update_OpacityBackground();
        }
        void Update_StretchImageSource()
        {
            if (this.imgBackgroundImage != null)
            {
                this.imgBackgroundImage.Stretch = StretchImage;

            }
        }
        void Update_Blur()
        {
            Debug.WriteLine(true);
            //WindowBlured.Blur(
            //    AccentState,
            //    this.HANDLE,
            //    this.IsBlur
            //);
        }

        void Update_AccentState()
        {
            this.Update_Blur();
        }
    }
}
