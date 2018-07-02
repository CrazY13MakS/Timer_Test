using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Timer_Test.Infrastructure
{
    /// <summary>
    /// Validate input value
    /// </summary>
    class SimpleTimerValidation : ValidationRule
    {

        public int SecondsMax { get; set; }
        public int SecondsMin { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           
            String str = value as String;
            if(!int.TryParse(str??String.Empty,out int seconds))
            {
                return new ValidationResult(false, $"Введенная строка имела неверный формат. Введите число");
            }            
            if ((seconds < SecondsMin) || (seconds > SecondsMax))
            {
                return new ValidationResult(false, "Введите число в диапазоне: " + SecondsMin + " - " + SecondsMax + ".");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
