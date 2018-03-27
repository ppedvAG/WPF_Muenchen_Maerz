using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Validierung
{
    public class StringNotEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Darf nicht leer sein!");
            }
           
            return ValidationResult.ValidResult;
        }
    }
}
