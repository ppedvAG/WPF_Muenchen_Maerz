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

namespace Validierung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //if((this.DataContext as Person).HasErrors)
            //{
            //    this.Background = Brushes.Violet;
            //}
            //else
            //{
            //    this.Background = Brushes.White;
            //}

            foreach (var item in stackpanel2.Children)
            {
                if(Validation.GetHasError((DependencyObject)item))
                {
                    foreach (var errorItem in Validation.GetErrors((DependencyObject)item))
                    {
                        MessageBox.Show(errorItem.ErrorContent.ToString());
                    }
                }
            }
        }

        private void Window_Error(object sender, ValidationErrorEventArgs e)
        {
            //MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }
}
