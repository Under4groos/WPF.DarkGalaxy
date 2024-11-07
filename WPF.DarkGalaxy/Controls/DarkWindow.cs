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

namespace WPF.DarkGalaxy.Controls
{
    [TemplatePart(Name = PART_MaxButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_MinButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_RestoreButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    
    public class DarkWindow : System.Windows.Window
    {
        private const string PART_MaxButton = "PART_MaxButton";
        private const string PART_MinButton = "PART_MinButton";
        private const string PART_RestoreButton = "PART_RestoreButton";
        private const string PART_CloseButton = "PART_CloseButton";
        private const string PART_BackgroundImage = "PART_BackgroundImage";

        private Button btnMax;
        private Button btnMin;
        private Button btnRestore;
        private Button btnClose;
        private ImageBrush imgBackgroundImage;
        private Stretch imageStretch;



        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));
           
        }

      

        public static readonly DependencyProperty ItemsSourceProperty =
           DependencyProperty.Register(
               nameof(BackgroundImage),
               typeof(string),
               typeof(DarkWindow),
               new FrameworkPropertyMetadata(OnItemsSourcePropertyChanged));

        public static readonly DependencyProperty StretchProperty =
           DependencyProperty.Register(
               nameof(imageStretch),
               typeof(Stretch),
               typeof(DarkWindow),
               new FrameworkPropertyMetadata(OnStretchImagePropertyChanged));
        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DarkWindow)d).UpdateSource();
        private static void OnStretchImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DarkWindow)d).UpdateStretchImageSource();

        public string BackgroundImage
        {
            get => (string)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        public Stretch StretchImage
        {
            get => (Stretch)GetValue(StretchProperty);
            set => SetValue(StretchProperty, value);
        }
        public void UpdateSource()
        {
            if(this.imgBackgroundImage != null && File.Exists(BackgroundImage))
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
        public void UpdateStretchImageSource()
        {
            if (this.imgBackgroundImage != null)
            {
                this.imgBackgroundImage.Stretch = StretchImage;

            }
        }
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
    }
}
