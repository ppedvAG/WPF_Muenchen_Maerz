using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XAMLDynamischLaden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //https://docs.microsoft.com/de-de/dotnet/framework/wpf/app-development/pack-uris-in-wpf
            //Resourcen, die kompiliert werden, müssen über folgende URL aufgerufen werden
            //Application.Current.Resources.Source = new Uri("pack://application:,,,/XAMLDynamischLaden;component/MyStyle.xaml");


            //für externe Resourcen siteOfOrigin statt application!
            //Application.Current.Resources.Source = new Uri("pack://siteOfOrigin:,,,/ExternalStyle.xaml");

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            //bei Embedded Resources muss der Pfad folgendermaßen sein:
            //pack://application:,,,/[Name der Assembly (muss in References eingebunden sein!)];component/[RelativerPfadzurDatei]
            logo.UriSource = new Uri("pack://application:,,,/XAMLDynamischLaden;component/Bilder/Fisch.jpg");
            logo.EndInit();


            image1.Source = logo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XAML-Datei|*.xaml";
            if(dialog.ShowDialog() == true)
            {
                using (FileStream stream = new FileStream(dialog.FileName, FileMode.Open))
                {

                    object rootElement = XamlReader.Load(stream);
                  
                    if(rootElement is ResourceDictionary dictionary)
                    {
                        Application.Current.Resources = dictionary;
                        //Application.Current.Resources.MergedDictionaries.Add(dictionary);
                    }
                    else
                    {
                        contentPresenter.Content = rootElement;
                        if(LogicalTreeHelper.FindLogicalNode(rootElement as DependencyObject, "button1") is Button btn)
                        {
                            btn.Click += (s, a) => { MessageBox.Show("Button1 Click!"); };   
                        }
                    }
                    MessageBox.Show(XamlWriter.Save(this));
                }
            }
        }
    }
}
