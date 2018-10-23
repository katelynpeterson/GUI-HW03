using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace KPeterson_HW03.ViewModel
{
    public class ViewModel_Project : INotifyPropertyChanged
    {
        Projects myProject = new Projects();

        public ObservableCollection<Projects> ProjectList
        {
            get; set;
        }

        public Projects NewProject { get; private set; }

        public ViewModel_Project()
        {

            ProjectList = new ObservableCollection<Projects>();

            NewProject = new Projects { ID = 1, StartDate = new DateTime(2018, 8, 3), Name = null, Type = "Personal", Time = new TimeSpan(1, 24, 4), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 1, 1), Skill = "UX" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 2, 1), Skill = "DB" });
            ProjectList.Add(NewProject);


            NewProject = new Projects { ID = 2, StartDate = new DateTime(2018, 8, 15), Name = "Project Awesome", Type = "Personal", Time = new TimeSpan(1, 56, 10), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info {ID= 2, Date = new DateTime(2018, 10, 5), Skill = "JS" });
            NewProject.Info.Add(new Info{ ID = 3, Date = new DateTime(2018, 12, 11), Skill = "HTML" });
            NewProject.Info.Add(new Info{ ID = 4, Date = new DateTime(2018, 2, 11), Skill = "CSS" });
            NewProject.Children.Add(new Projects { ID = 3, Name = "Awesome Baby", StartDate = new DateTime(2018, 10, 22) });
            NewProject.Children.Add(new Projects { ID = 3, Name = "Awesome Child", StartDate = new DateTime(2018, 10, 2) });
            ProjectList.Add(NewProject);

            NewProject = new Projects { ID = 3, StartDate = new DateTime(2018, 9, 6), Name = "Project NANO", Type = "Client", Time = new TimeSpan(13, 2, 44), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 7, 1), Skill = "HTML" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 7, 15), Skill = "SEO" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "JSON" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 8, 10), Skill = "PHP" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "CSS" });
            NewProject.Children.Add(new Projects { ID = 3, Name = "El Nino", StartDate = new DateTime(2018, 10, 15) });
            ProjectList.Add(NewProject);


            NewProject = new Projects { ID = 4, StartDate = new DateTime(2018, 10, 1), Name = "Project Cheese", Type = "School", Time = new TimeSpan(0, 50, 41), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 4), Skill = "JS" });
            NewProject.Info.Add(new Info { ID = 3, Date = new DateTime(2018, 9, 28), Skill = "PHP" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "CSS" });
            ProjectList.Add(NewProject);

            NewProject = new Projects { ID = 4, StartDate = new DateTime(2018, 10, 1), Name = "Demo", Type = "School", Time = new TimeSpan(0, 14, 9), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 4), Skill = "JS" });
            NewProject.Children.Add(new Projects { ID = 3, Name = "Wallaby", StartDate = new DateTime(2018, 11,12) });
            ProjectList.Add(NewProject);

            NewProject = new Projects { ID = 4, StartDate = new DateTime(2018, 10, 1), Name = "Omega", Type = "School", Time = new TimeSpan(0, 5, 0), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 4), Skill = "PHP" });
            ProjectList.Add(NewProject);

            //AddProject = new AddProjectCommand(ProjectList);
            SelectedProject = ProjectList.First();
        }

       // public ICommand AddProject { get; set; }

        private Projects selectedProject;
        public Projects SelectedProject
        {
            get { return selectedProject; }
            set { SetField(ref selectedProject, value); }
        }
        
        public Color RandColor()
        {

            Random randomGen = new Random(Guid.NewGuid().GetHashCode());
            return Color.FromRgb( (byte)randomGen.Next(255), (byte)randomGen.Next(255),
           (byte)randomGen.Next(255));
        }

        Stopwatch stopwatch = new Stopwatch();

        List<String> list = new List<string>();


        //Timing buttons
        private RelayCommand start_time;
        public RelayCommand StartTime => start_time ?? (start_time = new RelayCommand(
            () =>
            {
                if (!stopwatch.IsRunning)
                {
                    stopwatch.Start();
                }
            }));
       
        private RelayCommand stop_time;
        public RelayCommand StopTime => stop_time ?? (stop_time = new RelayCommand(
            () =>
            {
                stopwatch.Stop();
                myProject.Time = stopwatch.Elapsed;
            }));

        private RelayCommand submit_time;
        public RelayCommand SubmitTime => submit_time ?? (submit_time = new RelayCommand(
            () =>
            {
                if (stopwatch.Elapsed != null)
                {
                    myProject.Time = stopwatch.Elapsed;
                    
                    stopwatch.Reset();
                }
            }));


        public void print_time()
        {
            myProject.Time = stopwatch.Elapsed;
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

