using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CustomBinding
{
    public class MyBinding : Binding
    {
        public MyBinding()
        {
            base.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            base.Mode = BindingMode.TwoWay;
            base.NotifyOnValidationError = true;
            base.ValidatesOnDataErrors = true;
        }
    }
}
