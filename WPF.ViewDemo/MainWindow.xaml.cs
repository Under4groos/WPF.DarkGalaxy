using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.DarkGalaxy.Controls;
using WPF.DarkGalaxy.Controls.Part;

namespace WPF.ViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DarkWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }
        ContextMenu cm = new ContextMenu();
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cm.Items.Add(new MenuItem()
            {
                Header = "Open"
            });
            foreach (var item in new string[] { "File" , "Edit" , "Selection" })
            {
                this.LItems.Children.Add(new PART_Button()
                {
                    Content = item,
                    ContextMenu = cm
                });

                this.RItems.Children.Add(new PART_Button()
                {
                    Content = item,
                    ContextMenu = cm
                });
            }
           

           
        }
    }
}