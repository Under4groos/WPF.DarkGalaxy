using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF.DarkGalaxy.Controls.Part
{
    public class PART_Button : Button
    {
        private Border CornerBorder;


        private const string PART_Border = "PART_Border";


        static PART_Button()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PART_Button), new FrameworkPropertyMetadata(typeof(PART_Button)));
        }

        public static readonly DependencyProperty CornerRadiusProperty =
          DependencyProperty.Register(
              nameof(CornerRadius),
              typeof(CornerRadius),
              typeof(PART_Button),
              new FrameworkPropertyMetadata(OnUpdateCornerBorderPropertyChanged));
        private static void OnUpdateCornerBorderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((PART_Button)d).UpdateCornerBorder();


        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }


        void UpdateCornerBorder()
        {
            if (this.CornerBorder != null)

                this.CornerBorder.CornerRadius = this.CornerRadius;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.CornerBorder = this.GetTemplateChild(PART_Border) as Border;


            this.UpdateCornerBorder();
        }
    }
}
