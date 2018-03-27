using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Validierung
{
    public class ModelBase : INotifyDataErrorInfo
    {
        public bool HasErrors => (_errorListe.Count > 0);

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void AddOrRemoveError(bool isValid, string message, [CallerMemberName] string propertyName = null)
        {
            if (_errorListe.ContainsKey(propertyName))
            {
                List<string> errorMessages = _errorListe[propertyName];
                if (!isValid)
                {
                    if (!errorMessages.Contains(message))
                    {
                        errorMessages.Add(message);
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                    }
                }
                else
                {
                    if (errorMessages.Contains(message))
                    {
                        errorMessages.Remove(message);
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                    }
                }
            }
            else
            {
                if (!isValid)
                {
                    _errorListe.Add(propertyName, new List<string>() { message });
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                }
            }
        }

        private Dictionary<string, List<string>> _errorListe = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errorListe.ContainsKey(propertyName))
            {
                return _errorListe[propertyName];
            }
            return null;
        }
    }
}
