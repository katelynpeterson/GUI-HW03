using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KPeterson_HW03.ViewModel
{
    class ViewModel_TreeView : INotifyPropertyChanged
    {
        public ViewModel_TreeView(ObservableCollection<Projects> myProject)
        {
            ProjectList = myProject;
            SelectedPerson = ProjectList?.FirstOrDefault();
        }

        public ObservableCollection<Projects> ProjectList { get; }

        private  Projects selectedProject;
        public Projects SelectedPerson
        {
            get { return selectedProject; }
            set { SetField(ref selectedProject, value); }
        }
        //int childNumber = 1;
        //private RelayCommand addSinglePerson;
        //public RelayCommand AddSinglePerson => addSinglePerson ?? (addSinglePerson = new RelayCommand(
        //    () => SelectedPerson.Children.Add(new Projects() { Name = $"Child {childNumber++}" })));

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
