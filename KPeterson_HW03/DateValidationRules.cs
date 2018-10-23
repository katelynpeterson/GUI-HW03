using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KPeterson_HW03
{
    class DateValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime start = (DateTime)value;
            DateTime end = start.AddDays(1);
            return new ValidationResult(start < end, "End date must be after start date");
        }
    }
}
