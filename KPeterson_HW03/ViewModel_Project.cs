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
            NewProject.Info.Add(new Info(1, new DateTime(2018, 1, 1), "UX"));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 2, 1), "DB"));
            _projectList.Add(NewProject);
        }

        private ObservableCollection<Projects> _projectList;
        public ObservableCollection<Projects> ProjectList
        {
            get { return _projectList; }
        }

        private ICommand displayProjects;
        public ICommand DisplayProjects
        {

            get
            {
                return displayProjects
                    ?? (displayProjects = new ActionCommand(() =>
                    {
                        MakeProjects();
                    }));
            }
        }

        protected void MakeProjects()
        {
            _projectList = new ObservableCollection<Projects>();

            NewProject = new Projects(1, "Project Cool");
            NewProject.Info.Add(new Info(1, new DateTime(2018, 1, 1), "UX"));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 2, 1), "DB"));
            _projectList.Add(NewProject);


            NewProject = new Projects(2, "Project Awesome");
            NewProject.Info.Add(new Info(1, new DateTime(2018, 1, 1), "UX"));
            NewProject.Info.Add(new Info(1, new DateTime(2018, 2, 1), "DB"));
            _projectList.Add(NewProject);


            //c = new Projects() { ID = 3, Name = "Project NANO" };
            //c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 7, 1), Skill = "HTML" });
            //c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 7, 15), Skill = "SEO" });
            //c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "JSON" });
            //c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 8, 10), Skill = "PHP" });
            //c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "CSS" });
            //_projectList.Add(c);


            //c = new Projects() { ID = 4, Name = "Project Cheese" };
            //c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 9, 4), Skill = "JS" });
            //c.Info.Add(new Info() { ID = 3, Date = new DateTime(2018, 9, 28), Skill = "PHP" });
            //c.Info.Add(new Info() { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "CSS" });
            //_projectList.Add(c);
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
    public class ActionCommand : ICommand
    {
        private readonly Action _action;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }

}

