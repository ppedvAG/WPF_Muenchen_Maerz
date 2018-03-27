using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XAML_Zu_CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Per Code Grid und Button zum Window hinzufügen
            //Grid grid = new Grid();
            //Button button = new Button();
            //button.VerticalAlignment =  VerticalAlignment.Center;
            //button.HorizontalAlignment = HorizontalAlignment.Center;
            //button.Content = "Klick mich!";

            //grid.Children.Add(button);

            //this.Content = grid;

            grid1.Children.Add(new Button() { Content = "Neuer Button zur Laufzeit", VerticalAlignment = VerticalAlignment.Top });
            //button1.Content = "neue Beschriftung";
            
        }
    }
}
