using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFGoogleBooksMVVM
{
    public class BookResultsViewModel
    {
        public ObservableCollection<Book> BuchListe { get; set; }

        public BookResultsViewModel(Book[] liste)
        {
            //Mittels Kopierkonstruktor wird das Buch-Array in den Datentyp
            //ObservableCollection umgewandelt
            this.BuchListe = new ObservableCollection<Book>(liste);
        }

        public OneParameterCommand OpenWebsite { get; set; } =
            new OneParameterCommand(
                (p) => 
                {
                    if(p is Book book)
                    {
                        Process.Start(book.VolumeInfo.PreviewLink);
                    }
                }
            );

        public OneParameterCommand ChangeFavoritState { get; set; } =
            new OneParameterCommand(
                (p) =>
                {
                    if(p is Book book)
                    {
                        book.Favorit = !book.Favorit;
                        BookServices.AddOrRemoveBookToFavorites(book);
                    }
                }
            );

        public BookResultsViewModel()
        {

        }
    }
}
