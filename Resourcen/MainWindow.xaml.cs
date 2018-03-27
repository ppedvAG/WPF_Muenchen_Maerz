using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Resourcen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SolidColorBrush brush = new SolidColorBrush() { Color = Colors.Red };
            Button btn = new Button() { Background = brush };
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is MenuItem item)
            {
                //Ermitteln welche Schriftgröße gesetzt werden soll
                int newFontSize = int.Parse(item.Tag.ToString());
                Application.Current.Resources["windowFontSize"] = (double)newFontSize;
                (new MainWindow()).Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Application.Current.Resources["windowFontSize"].ToString());

            if(sender is Button btn)
            {

                DockPanel.SetDock(btn, Dock.Right);
                DockPanel.GetDock(btn);

                if(btn.TryFindResource("windowFasdasontSize") != null)
                {
                    MessageBox.Show(btn.FindResource("windowFontSize").ToString());
                }
                else
                {
                    MessageBox.Show("Resource existiert nicht!");
                }
            }
        }
    }
}
