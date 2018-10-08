using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KPeterson_HW03
{
    public class ViewModel_MainWindow :INotifyPropertyChanged
    {
        private ProjectButton projectBtn;

        public ProjectButton ProjectBtn
        {
            get { return projectBtn; }
            set { projectBtn = value; }
        }

        private double maxRange;
        public double MaxRange
        {
            get { return maxRange; }
            set { SetField(ref maxRange, value); }
        }

        private double minRange;
        public double MinRange
        {
            get { return minRange; }
            set { SetField(ref minRange, value); }
        }

        public BindingList<ProjectButton> MyProjects { get; set; }

        public ViewModel_MainWindow()
        {
            maxRange = 300;
            minRange = 80;

            MyProjects = new BindingList<ProjectButton>(new[] 
            { 
            new ProjectButton {BtnHeight = 80, Name = "Project NANO"},
            new ProjectButton {BtnHeight = 80, Name = "Project Cheese"},
            new ProjectButton {BtnHeight = 80, Name = "Project Awesome"},
            new ProjectButton {BtnHeight = 80, Name = "Project GUI"},
            new ProjectButton {BtnHeight = 80, Name = "Project Cool"},
            }.ToList());
        }
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
