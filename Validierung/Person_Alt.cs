using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validierung
{
    //Bei eigenen Klassen, die fürs Binding genutzt werden, INotifyPropertyChanged implementieren
    public class PersonAlt : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        private Dictionary<string, List<string>> fehlerListe = new Dictionary<string, List<string>>();

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name darf nicht leer sein!");
                }
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private int _alter;

        public int Alter
        {
            get { return _alter; }
            set
            {
                //Fehlerfall
                if(value < 0 || value > 120)
                {
                    //Fehlertabelle befüllen
                    if (!fehlerListe.ContainsKey(nameof(Alter)))
                    {
                        fehlerListe.Add(nameof(Alter), new List<string>() { "Alter muss zwischen 0 und 120 sein!" });
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Alter)));
                    }
                }
                //Kein Fehler
                else if(fehlerListe.ContainsKey(nameof(Alter)))
                {
                    fehlerListe.Remove(nameof(Alter));
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Alter)));
                }

                _alter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }


        private bool _volljährig;

        public bool Volljährig
        {
            get { return _volljährig; }
            set
            {
                _volljährig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Volljährig)));
            }
        }

        private string _fotoUrl;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public string FotoUrl
        {
            get { return _fotoUrl; }
            set
            {
                _fotoUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FotoUrl)));
            }
        }

        public bool HasErrors
        {
            get
            {
                return fehlerListe.Count > 0;
            }
        }

        public override string ToString()
        {
            string volljährigAsString = Volljährig ? "volljährig" : "nicht volljährig";

            return $"{Name} ist {volljährigAsString}";
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if(fehlerListe.ContainsKey(propertyName)) {
                return fehlerListe[propertyName];
            }
            //Leere Liste wird als "Es gibt keine Fehler" interpretiert
            return new List<string>();
        }
    }
}
