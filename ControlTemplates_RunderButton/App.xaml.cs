using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControlTemplates_RunderButton
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(sender is Border border)
            {
                border.Tag = border.Background;
                border.Background = Brushes.Blue;
            }
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Border border)
            {
                border.Background = (Brush)border.Tag;
            }
        }
    }
}
