using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace KPeterson_HW03.ViewModel
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

            NewProject = new Projects { ID = 1, StartDate = new DateTime(2018, 8, 3), Name = "Project Cool", Type = "Personal", Time = new TimeSpan(1, 24, 4), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 1, 1), Skill = "UX" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 2, 1), Skill = "DB" });
            _projectList.Add(NewProject);


            NewProject = new Projects { ID = 2, StartDate = new DateTime(2018, 8, 15), Name = "Project Awesome", Type = "Personal", Time = new TimeSpan(1, 56, 10), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info {ID= 2, Date = new DateTime(2018, 10, 5), Skill = "JS" });
            NewProject.Info.Add(new Info{ ID = 3, Date = new DateTime(2018, 12, 11), Skill = "HTML" });
            NewProject.Info.Add(new Info{ ID = 4, Date = new DateTime(2018, 2, 11), Skill = "CSS" });
            _projectList.Add(NewProject);

            NewProject = new Projects { ID = 3, StartDate = new DateTime(2018, 9, 6), Name = "Project NANO", Type = "Client", Time = new TimeSpan(13, 2, 44), ProjectColor = RandColor() };
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 7, 1), Skill = "HTML" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 7, 15), Skill = "SEO" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "JSON" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 8, 10), Skill = "PHP" });
            NewProject.Info.Add(new Info { ID = 1, Date = new DateTime(2018, 9, 10), Skill = "CSS" });
            _projectList.Add(NewProject);


            NewProject = new Projects { ID = 4, StartDate = new DateTime(2018, 10, 1), Name = "Project Cheese", Type = "School", Time = new TimeSpan(0, 50, 41), ProjectColor = RandColor() };
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

        public Color RandColor()
        {
            Random randomGen = new Random();
            return Color.FromRgb((byte)randomGen.Next(255), (byte)randomGen.Next(255),
           (byte)randomGen.Next(255));
        }

        Stopwatch stopwatch = new Stopwatch();
        TimeSpan ts = new TimeSpan();
        string elapsedTime = "";
        DateTime today = DateTime.Today;

        private string currentTime;
        public string CurrentTime
        {
            get { return currentTime; }
            set { SetField(ref currentTime, value); }
        }


        List<String> list = new List<string>();

      
        //Timing buttons
        public void start_time(object sender, RoutedEventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                CurrentTime = "Start";
                stopwatch.Start();
            }
        }

        public void print_time()
        {
            ts = stopwatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            CurrentTime = elapsedTime;

        }

        public void stop_time(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            CurrentTime = "Stop";
        }

        public void submit_time(object sender, RoutedEventArgs e)
        {
            if (stopwatch.Elapsed != null)
            {
                ts = stopwatch.Elapsed;

                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);

                list.Add(today.ToString("MM/dd/yyyy") + " " + elapsedTime);

                stopwatch.Reset();
                CurrentTime = String.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            }
        }

        public string TimeSpent()
        {
            return elapsedTime;
        }

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

        public void projectbuttoninitializer()
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

