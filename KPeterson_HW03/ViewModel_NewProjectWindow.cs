using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace KPeterson_HW03
{
    class ViewModel_NewProjectWindow: INotifyPropertyChanged//, IDataErrorInfo
    {
        

        //public string Error => throw new NotImplementedException();

        //public string this[string propertyName]
        //{
        //    get
        //    {
        //        if (propertyName == nameof(Projects.Name))
        //        {
        //            if (Projects.Name.Equals(null))
        //            {
        //                return "The project must have a name.";
        //            }
        //        }
        //        return null;

        //    }
        //}
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }

}
