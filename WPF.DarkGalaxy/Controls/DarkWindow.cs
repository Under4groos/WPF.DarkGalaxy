using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Interop;
using WPF.DarkGalaxy.Helper;
using System.Windows.Media.Effects;

namespace WPF.DarkGalaxy.Controls
{
    [TemplatePart(Name = PART_MaxButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_MinButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_RestoreButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_LeftItems, Type = typeof(StackPanel))]
    public class DarkWindow : System.Windows.Window
    {
        private const string PART_MaxButton = "PART_MaxButton";
        private const string PART_MinButton = "PART_MinButton";
        private const string PART_RestoreButton = "PART_RestoreButton";
        private const string PART_CloseButton = "PART_CloseButton";
        private const string PART_BackgroundImage = "PART_BackgroundImage";
        private const string PART_LeftItems = "PART_LeftItems";
        private const string PART_RightItems = "PART_RightItems";
        private const string PART_BackgroundBlur = "PART_BackgroundBlur";
        private Button btnMax;
        private Button btnMin;
        private Button btnRestore;
        private Button btnClose;
        private ImageBrush imgBackgroundImage; 
        public StackPanel LItems;
        public StackPanel RItems;
        private bool _IsBlured
        {
            get; set;
        }
        private IntPtr _HANDLE = IntPtr.Zero;
        private BlurEffect blurEffect;


        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));    
        }

        #region Binding
        public static readonly DependencyProperty OpacityBackgroundProperty =
           DependencyProperty.Register(
               nameof(OpacityBackground),
               typeof(double),
               typeof(DarkWindow),
               new FrameworkPropertyMetadata(OnOpacityBackgroundPropertyChanged));
        public static readonly DependencyProperty BackgroundImageProperty =
           DependencyProperty.Register(
               nameof(BackgroundImage),
               typeof(string),
               typeof(DarkWindow),
               new FrameworkPropertyMetadata(OnItemsSourcePropertyChanged));
        public static readonly DependencyProperty StretchProperty =
           DependencyProperty.Register(
               nameof(StretchImage),
               typeof(Stretch),
               typeof(DarkWindow),
               new FrameworkPropertyMetadata(OnStretchImagePropertyChanged));

        public static readonly DependencyProperty BackgroundImageBluredProperty =
          DependencyProperty.Register(
              nameof(BackgroundImageBlured),
              typeof(double),
              typeof(DarkWindow),
              new FrameworkPropertyMetadata(OnBackgroundImageBluredPropertyChanged));


        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DarkWindow)d).UpdateSource();
        private static void OnStretchImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DarkWindow)d).UpdateStretchImageSource();

        private static void OnOpacityBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DarkWindow)d).UpdateOpacityBackground();

        private static void OnBackgroundImageBluredPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DarkWindow)d).UpdateOpacityBackground();

        public double BackgroundImageBlured
        {
            get => (double)GetValue(BackgroundImageBluredProperty);
            set => SetValue(BackgroundImageBluredProperty, value);
        }
        public string BackgroundImage
        {
            get => (string)GetValue(BackgroundImageProperty);
            set => SetValue(BackgroundImageProperty, value);
        }
        public double OpacityBackground
        {
            get => (double)GetValue(OpacityBackgroundProperty);
            set => SetValue(OpacityBackgroundProperty, value);
        }
        public Stretch StretchImage
        {
            get => (Stretch)GetValue(StretchProperty);
            set => SetValue(StretchProperty, value);
        } 
        #endregion



        #region nobinding
        public IntPtr HANDLE
        {
            get
            {
                if(_HANDLE == IntPtr.Zero)
                    _HANDLE = new WindowInteropHelper(this).Handle;
                return _HANDLE;
            }
        }
        public Helper.Enums.AccentState AccentState
        {
            get; set;
        } = Helper.Enums.AccentState.ACCENT_ENABLE_BLURBEHIND;
        public bool IsBlured
        {
            get
            {
                return _IsBlured;
            }
            set
            {
                if (value == _IsBlured)
                    return;

                WindowBlured.Blur(
                    AccentState,
                    this.HANDLE,
                    value
                    );

                _IsBlured = value;
            }
        }
        #endregion

        public DarkWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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


            this.UpdateSource();
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
        void UpdateOpacityBackground()
        {
            if(this.imgBackgroundImage != null && this.blurEffect != null)
            {
                this.imgBackgroundImage.Opacity = this.OpacityBackground;
                this.blurEffect.Radius = this.BackgroundImageBlured;
            }
               
        }

        void UpdateSource()
        {
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
            this.UpdateOpacityBackground();
        }
        void UpdateStretchImageSource()
        {
            if (this.imgBackgroundImage != null)
            {
                this.imgBackgroundImage.Stretch = StretchImage;

            }
        }
    }
}
