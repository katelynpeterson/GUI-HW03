using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SharedViewModel;

namespace KPeterson_HW03
{
    class Dependencies : DependencyObject
    {
        public DateTime MaxDate
        {
            get { return (DateTime)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxDateProperty =
            DependencyProperty.Register("MaxDate", typeof(DateTime), typeof(Projects), new PropertyMetadata(0));




        public DateTime MinDate
        {
            get { return (DateTime)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinDateProperty =
            DependencyProperty.Register("MinDate", typeof(DateTime), typeof(Projects), new PropertyMetadata(0));


    }
}
