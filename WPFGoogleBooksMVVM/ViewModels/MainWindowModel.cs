using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFGoogleBooksMVVM.Views;

namespace WPFGoogleBooksMVVM
{
    public class MainWindowModel
    {
        public string Suchbegriff { get; set; } = "WPF";

        public OneParameterCommand Suche { get; set; }
        public OneParameterCommand Favoriten { get; set; }
            = new OneParameterCommand(
                (p) =>
                {
                    BookResultsView view = new BookResultsView();
                    view.DataContext = new BookResultsViewModel(BookServices.FavoritBooksDBContext.Books.Local.ToArray());
                    view.ShowDialog();
                },
                (p) =>
                {
                    //Favoritenliste nur anzeigen wenn Favoriten vorhanden sind
                    return (BookServices.FavoritBooksDBContext.Books.Local.Count > 0);
                }
            );

        public MainWindowModel()
        {
            Suche = new OneParameterCommand(SucheBuch, BuchSuchbar);
        }


        //Methode die beim Klick auf den Button ausgeführt werden soll
        private void SucheBuch(object parameter)
        {
            BookList liste = BookServices.SucheBuch(Suchbegriff);

            //Neues View initialisieren
            BookResultsView view = new BookResultsView();

            //DatenContext des neuen Views mit ViewModel verknüpfen
            view.DataContext = new BookResultsViewModel(liste.Items);

            //View anzeigen
            view.ShowDialog();
        }

        private bool BuchSuchbar(object parameter)
        {
            //Bei leerem Suchbegriff darf keine Buchsuche stattfinden
            return !string.IsNullOrEmpty(Suchbegriff);

            //Alternative Schreibweise
            //if (Suchbegriff == "") return false;
            //return true;
        }
    }
}
