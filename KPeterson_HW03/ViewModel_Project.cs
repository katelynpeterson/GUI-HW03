using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace KPeterson_HW03
{
    public class ViewModel_Project : INotifyPropertyChanged

    {
        public ViewModel_Project()
        {
            _projectList = new ObservableCollection<Projects>();

            NewProject = new Projects(1, "Project Cool");
            NewProject.Info.Add(new Info(1, new DateTime(2018, 1, 1), "UX"));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 2, 1), "DB"));
            _projectList.Add(NewProject);


            NewProject = new Projects(2, "Project Awesome");
            NewProject.Info.Add(new Info(2, new DateTime(2018, 10, 5), "JS"));
            NewProject.Info.Add(new Info(3, new DateTime(2018, 12, 11), "HTML"));
            NewProject.Info.Add(new Info(4, new DateTime(2018, 2, 11), "CSS"));
            _projectList.Add(NewProject);

            NewProject = new Projects(3, "Project NANO" );
            NewProject.Info.Add(new Info(1, new DateTime(2018, 7, 1), "HTML" ));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 7, 15), "SEO" ));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 9, 10), "JSON" ));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 8, 10), "PHP" ));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 9, 10), "CSS" ));
            _projectList.Add(NewProject);


            NewProject = new Projects(4, "Project Cheese" );
            NewProject.Info.Add(new Info(1, new DateTime(2018, 9, 4), "JS" ));
            NewProject.Info.Add(new Info(3, new DateTime(2018, 9, 28), "PHP" ));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 9, 10), "CSS" ));
            _projectList.Add(NewProject);

        }

        private ObservableCollection<Projects> _projectList;
        public ObservableCollection<Projects> ProjectList
        {
            get { return _projectList; }
        }

            public Projects NewProject { get; private set; }

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

