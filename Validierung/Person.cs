using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validierung
{
    public class Person : ModelBase, INotifyPropertyChanged
    {

        private Dictionary<string, List<string>> fehlerListe = new Dictionary<string, List<string>>();

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                AddOrRemoveError(!string.IsNullOrEmpty(value), "Name darf nicht leer sein");
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

                AddOrRemoveError(value >= 0 && value <= 120, "Alter muss zwischen 0 und 120 sein");
                AddOrRemoveError(value % 2 == 0, "Alter muss eine gerade Zahl sein!");

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
                AddOrRemoveError(value == (Alter > 18), "Volljährigkeit ab 18 Jahren!");

                _volljährig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Volljährig)));
            }
        }

        private string _fotoUrl;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FotoUrl
        {
            get { return _fotoUrl; }
            set
            {
                _fotoUrl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FotoUrl)));
            }
        }

        public override string ToString()
        {
            string volljährigAsString = Volljährig ? "volljährig" : "nicht volljährig";

            return $"{Name} ist {volljährigAsString}";
        }
    }
}
