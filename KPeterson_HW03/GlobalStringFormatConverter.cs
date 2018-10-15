﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KPeterson_HW03
{
    [ValueConversion(typeof(object), typeof(string))]
    class GlobalStringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                      System.Globalization.CultureInfo culture)
        {
            string format = parameter as string;
            if (!string.IsNullOrEmpty(format))
            {
                return string.Format(culture, format, value);
            }
            else
            {
                return value.ToString();
            }
        }
            public object ConvertBack(object value, Type targetType, object parameter,
                            System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
    
}