using System.Windows;

namespace WPF.DarkGalaxy.Sys
{
    public static class SysDependencyProperty<T>
    {
        //public static readonly DependencyProperty OpacityBackgroundProperty =
        //   DependencyProperty.Register(
        //       nameof(OpacityBackground),
        //       typeof(double),
        //       typeof(DarkWindow),
        //       new FrameworkPropertyMetadata(OnOpacityBackgroundPropertyChanged));

        // public static DependencyProperty Register(
        // string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata, ValidateValueCallback validateValueCallback);
        // public delegate void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e);
        public static DependencyProperty RegisterA(string name, Type propertyType, Type ownerType, Action<T, DependencyPropertyChangedEventArgs> EventArgs)
        {

            return DependencyProperty.Register(
               name,
               propertyType,
               ownerType,
               new FrameworkPropertyMetadata((DependencyObject d, DependencyPropertyChangedEventArgs e) =>
               {
                   if (d is T t)
                   {
                       EventArgs?.Invoke(t, e);
                   }
               }));

        }
        public static DependencyProperty RegisterW(string name, Type propertyType, Type ownerType, object value, Action<T, DependencyPropertyChangedEventArgs> EventArgs)
        {

            return DependencyProperty.Register(
               name,
               propertyType,
               ownerType,
               new FrameworkPropertyMetadata(value, (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
               {
                   if (d is T t)
                   {
                       EventArgs?.Invoke(t, e);
                   }
               }));

        }
    }
}
