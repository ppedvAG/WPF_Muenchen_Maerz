using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFGoogleBooksMVVM.Models;

namespace WPFGoogleBooksMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Datenbank laden
            BookServices.LoadFavoriteBooksFromDB();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //Datenbank speichern
            BookServices.FavoritBooksDBContext.SaveChanges();
            base.OnExit(e);
        }
    }
}