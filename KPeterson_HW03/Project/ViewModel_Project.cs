using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace KPeterson_HW03
{
    public class ViewModel_Project : INotifyPropertyChanged

    {
        private ObservableCollection<Projects> _projectList;
        public ObservableCollection<Projects> ProjectList
        {
            get { return _projectList; }
        }

        public Projects NewProject { get; private set; }

        public ViewModel_Project()
        {
            _projectList = new ObservableCollection<Projects>();

            NewProject = new Projects { ID = 1, StartDate=new DateTime(2018,8,3), Name = "Project Cool" };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 1, 1), Skill = "UX" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 2, 1), Skill = "DB" });
            _projectList.Add(NewProject);


            NewProject = new Projects { ID = 2, StartDate = new DateTime(2018, 8, 15), Name = "Project Awesome" };
            NewProject.Info.Add(new Info {ID= 2, Date = new DateTime(2018, 10, 5), Skill = "JS" });
            NewProject.Info.Add(new Info{ ID = 3, Date = new DateTime(2018, 12, 11), Skill = "HTML" });
            NewProject.Info.Add(new Info{ ID = 4, Date = new DateTime(2018, 2, 11), Skill = "CSS" });
            _projectList.Add(NewProject);

            NewProject = new Projects { ID = 3, StartDate = new DateTime(2018, 9, 6), Name = "Project NANO" };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 7, 1), Skill = "HTML" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 7, 15), Skill = "SEO" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "JSON" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 8, 10), Skill = "PHP" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "CSS" });
            _projectList.Add(NewProject);


            NewProject = new Projects { ID = 4, StartDate = new DateTime(2018, 10, 1), Name = "Project Cheese" };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 4), Skill = "JS" });
            NewProject.Info.Add(new Info { ID = 3, Date = new DateTime(2018, 9, 28), Skill = "PHP" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "CSS" });
            _projectList.Add(NewProject);

        }

        private Projects selectedProject;
        public Projects SelectedProject
        {
            get { return selectedProject; }
            set { SetField(ref selectedProject, value); }
        }


        public void MenuClick_Calendar()
        {
            var calendarWindow = new Calendar();
            calendarWindow.Show();
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

