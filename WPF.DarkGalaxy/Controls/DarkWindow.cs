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
        private Image imgBackgroundImage;

        static DarkWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DarkWindow), new FrameworkPropertyMetadata(typeof(DarkWindow)));
        }

      

        public static readonly DependencyProperty ItemsSourceProperty =
           DependencyProperty.Register(
               nameof(BackgroundImage),
               typeof(ImageSource),
               typeof(DarkWindow),
               new FrameworkPropertyMetadata(OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((DarkWindow)d).UpdateSource();       
        

        public ImageSource BackgroundImage
        {
            get => (ImageSource)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public void UpdateSource()
        {
            if(this.imgBackgroundImage != null)
            {

                 
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.btnMax = this.GetTemplateChild(PART_MaxButton) as Button;
            this.btnMin = this.GetTemplateChild(PART_MinButton) as Button;
            this.btnRestore = this.GetTemplateChild(PART_RestoreButton) as Button;
            this.btnClose = this.GetTemplateChild(PART_CloseButton) as Button;
            this.imgBackgroundImage = this.GetTemplateChild(PART_BackgroundImage) as Image;

            


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
