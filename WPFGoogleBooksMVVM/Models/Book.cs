using System;
using System.Collections.Generic;
using System.Net;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPFGoogleBooksMVVM
{

    //Diese Klassen wurden mithilfe von http://json2csharp.com/ erzeugt
    //Alle Properties, die fürs Programm nicht benötigt werden, wurden entfernt
    //Zudem wurde neue Properties wie VolumeInfoID und ImageLinksID fürs Entitiy-Framework hinzugefügt

    public class BookList
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("totalItems")]
        public long TotalItems { get; set; }

        [JsonProperty("items")]
        public Book[] Items { get; set; }
    }

    public class Book
    {

        public bool Favorit { get; set; } = false;

        [JsonProperty("id")]
        public string BookId { get; set; }

        [JsonProperty("volumeInfo")]
        public virtual VolumeInfo VolumeInfo { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Book b)
            {
                return b.BookId == this.BookId;
            }
            return base.Equals(obj);
        }
    }

    public class VolumeInfo
    {
        private const char trennzeichen = ';';
        

        public int VolumeInfoID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [NotMapped]
        [JsonProperty("authors")]
        public string[] _authors { get; set; }

        public string Authors
        {
            get
            {
                return string.Join($"{trennzeichen}", _authors);
            }
            set
            {
                _authors = value.Split(trennzeichen);
            }
        }

        [JsonProperty("imageLinks")]
        public ImageLinks ImageLinks { get; set; }

        [JsonProperty("previewLink")]
        public string PreviewLink { get; set; }
    }

    public class ImageLinks
    {
        int ImageLinksID { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}