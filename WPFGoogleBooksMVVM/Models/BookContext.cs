using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGoogleBooksMVVM.Models
{
    //Entity Framework per Nuget-Package-Manager installieren
    //Die Datenbank kann über 
    //View->SQL Server Object Explorer->localdb->Databases->WPFGoogleBooksMVVM.Models.BookContext verwaltet werden
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<VolumeInfo> VolumeInfos { get; set; }
    }
}