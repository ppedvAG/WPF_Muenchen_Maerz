using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFGoogleBooksMVVM
{
    public class OneParameterCommand : ICommand
    {
        //Delegate Datentyp
        public delegate void ExecuteMethodDelegate(object parameter);
        public delegate bool CanExecuteMethodDelegate(object parameter);

        //Generische Delegate-Typen
        //https://www.dotnetperls.com/delegate
        //Action<object> ExecuteMethodDelegate;
        //Func<object, bool> CanExecuteMethodDelegate; 

        private ExecuteMethodDelegate executeMethod = null;
        private CanExecuteMethodDelegate canExecuteMethod = null;
        
        //Dieser Code sorgt dafür, dass der EventHandler, der demn
        //CanExecuteChanged-Delegate zugewiesen werden soll,
        //zum Event RequerySuggested der CommandManager-Klasse weitergereicht wird
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public OneParameterCommand(ExecuteMethodDelegate exec, CanExecuteMethodDelegate canExec = null)
        {
            this.executeMethod = exec;
            this.canExecuteMethod = canExec;
        }

        public bool CanExecute(object parameter)
        {
            if(this.canExecuteMethod != null)
            {
                return canExecuteMethod.Invoke(parameter);
            }
            return true;
        }

        //parameter steht für den Wert, der in XAML mittels CommandParameter gesetzt wurde
        //z.B. <Button Command="{Binding Suche}" CommandParameter="Test" />
        public void Execute(object parameter)
        {
            executeMethod?.Invoke(parameter);
        }
    }
}
