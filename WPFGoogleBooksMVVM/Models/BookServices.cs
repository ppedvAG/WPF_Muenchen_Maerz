using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPFGoogleBooksMVVM.Models;

namespace WPFGoogleBooksMVVM
{
    public class BookServices
    {
        //Entitiy-Framework Datenbank Obejekt, mit dem auf die Favoriten-Datenbank zugegriffen werden kann
        public static BookContext FavoritBooksDBContext = new BookContext();

        public static void LoadFavoriteBooksFromDB()
        {
            FavoritBooksDBContext.Books.Load();
        }

        public static void AddOrRemoveBookToFavorites(Book book)
        {
            bool favorit = book.Favorit;

            if (favorit && !FavoritBooksDBContext.Books.Local.Contains(book))
            {
                //Fügt Datensatz zum Datenbank-Context-Objekt hinzu
                //Erst beim Speichern der Datenbank am Ende des Programmes werden diese Änderungen
                //tatsächlich in die DB geschrieben
                FavoritBooksDBContext.Books.Add(book);
            }
            else if (!favorit && FavoritBooksDBContext.Books.Local.Contains(book))
            {
                FavoritBooksDBContext.Books.Local.Remove(book);
            }
        }

        public static BookList SucheBuch(string suchbegriff)
        {
            //Webservice ansteuern
            HttpClient client = new HttpClient();
            string result = client.GetStringAsync($"https://www.googleapis.com/books/v1/volumes?q={suchbegriff}").Result;
            //Wandle den JSON-String vom Webservice in ein BookList-Objekt um
            BookList buchliste = JsonConvert.DeserializeObject<BookList>(result);

            foreach (var book in buchliste.Items)
            {
                Book b = FavoritBooksDBContext.Books.Local.SingleOrDefault(bo => bo.BookId == book.BookId);
                if (b is Book )
                {
                    book.Favorit = b.Favorit;
                }
            }

            return buchliste;
        }
    }
}
