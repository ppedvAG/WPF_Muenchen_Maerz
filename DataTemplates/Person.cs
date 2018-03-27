using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplates
{
    //Bei eigenen Klassen, die fürs Binding genutzt werden, INotifyPropertyChanged implementieren
    public class Person : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
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

        public string FotoUrl
        {
            get { return _fotoUrl; }
            set { _fotoUrl = value;
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
