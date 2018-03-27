using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Validierung
{
    public class IntegerBetween0And120Rule : ValidationRule
    {
        public int MinValue { get; set; } = 0;
        public int MaxValue { get; set; } = 120;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(int.TryParse(value.ToString(), out int wert))
            {
                if (wert < MinValue || wert > MaxValue)
                {
                    return new ValidationResult(false, $"Wert muss zwischen {MinValue} und  {MaxValue} liegen");
                }
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Leerer String!");
        }
    }
}
