using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataTemplates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Beim Binding von dynamischen Listen immer die Klasse ObservableCollection
        private ObservableCollection<Person> personenListe = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();

            //Simuliere die Erzeugung der Daten aus einer Datenbank
            personenListe.Add(new Person() { Name = "Boris Becker", Volljährig = true, FotoUrl = "https://i.pinimg.com/474x/b0/9d/b8/b09db8972eddaf7f1bdb1c3fa117cb11--boris-becker-sports-stars.jpg" });
            personenListe.Add(new Person() { Name = "Harry Potter", Volljährig = false, FotoUrl = "https://pbs.twimg.com/profile_images/876137969777823745/BE-fu86q_400x400.jpg" });

            this.DataContext = personenListe;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            personenListe[0].Name = "neuer Name";
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image)
            {
                MessageBox.Show(image.Source.ToString());
                //Logik für Anzeigen des Bildes im Großformat in externen Programm
            }
        }

        private void Button_Click_NeuePerson(object sender, RoutedEventArgs e)
        {
            personenListe.Add(new Person()
            {
                Name = "Testperson",
                Volljährig = true,
                FotoUrl = "https://efraimstochter.de/medien/Pippi-Langstrumpf.jpg"            }
            );
        }
    }
}
