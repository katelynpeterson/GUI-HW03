using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace KPeterson_HW03
{
    public class Projects : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _id;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _name;
        private string _type;
       
        private ObservableCollection<Info> _info
            = new ObservableCollection<Info>();

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
                validateProjectDate();
            }
        }

        public DateTime EstimatedEndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private void validateProjectDate()
        {
            if (StartDate.Equals("") || StartDate.Equals(null))
            {
                errors[nameof(StartDate)] = "Project must have a start date.";
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private TimeSpan _time;
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }


        public ObservableCollection<Info> Info
        {
            get { return _info; }
        }

        public class ProjectType
        {
            public ProjectType(string name, int id)
            {
                ProjectTypeName = name;
                Id = id;
            }
            public string ProjectTypeName { get; set; }
            public int Id { get; set; }
        }

        public ObservableCollection<ProjectType> ProjectTypes { get; } = new ObservableCollection<ProjectType>(new[] { new ProjectType("Client",1), new ProjectType("Personl",2), new ProjectType("School",3) });

        public string Error => throw new NotImplementedException();
        private Dictionary<string, string> errors = new Dictionary<string, string>();

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == nameof(Name))
                {
                    if (Name.Equals("") || Name.Equals(null))
                    {
                        return errors[nameof(Name)] = "The project must have a name.";
                    }
                }
                if (propertyName == nameof(Type))
                {
                    if (Type.Equals("") || Type.Equals(null))
                    {
                        return errors[nameof(Type)] = "You cannot add an empty type.";
                    }
                }
                
                return null;

            }
        }

        #region INotifyPropertyChanged Members 


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        #endregion
    }


    public class Info : INotifyPropertyChanged
    {
        private int _id;
        private DateTime _date;
        private string _skill;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }


        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
               OnPropertyChanged("Date");
            }
        }


        public string Skill
        {
            get { return _skill; }
            set
            {
                _skill = value;
               OnPropertyChanged("Skill");
            }
        }
        #region INotifyPropertyChanged Members 


        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        #endregion

    }
}
