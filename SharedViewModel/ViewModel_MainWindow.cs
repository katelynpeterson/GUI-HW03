using GalaSoft.MvvmLight.Command;
using SharedViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ViewModel_MainWindow : INotifyPropertyChanged
    {
        public ViewModel_MainWindow()
        {
            ChildViewModels = new ObservableCollection<ChildControl>();
            Projectvm = new ViewModel_Project();
            ChildViewModels.Add(new ChildControl("New Project",Projectvm));
            SelectedChildViewModel = ChildViewModels.Last();
        }

        private ChildControl selectedChildViewModel;
        public ChildControl SelectedChildViewModel
        {
            get { return selectedChildViewModel; }
            set { SetField(ref selectedChildViewModel, value); }
        }

        private ViewModel_Project projectvm;
        public ViewModel_Project Projectvm
        {
            get { return projectvm; }
            set { SetField(ref projectvm, value); }
        }


        private ObservableCollection<ChildControl> childViewModels;
        public ObservableCollection<ChildControl> ChildViewModels
        {
            get { return childViewModels; }
            set { SetField(ref childViewModels, value); }
        }

        private RelayCommand addNewProject;
        public RelayCommand AddNewProject => addNewProject ?? (addNewProject = new RelayCommand(
            () =>
            {
                var project = Projectvm.ProjectList;
                project.Add(new Projects()
                {
                    Name = "New Project",
                    StartDate = DateTime.Today,
                    Type = "Personal"
                });
            }));

        private RelayCommand treeView;
        public RelayCommand TreeView => projectSummary ?? (treeView = new RelayCommand(
            () =>
            {
                var mostRecentProjectTreeViewModel = (ViewModel_Project)(ChildViewModels.FirstOrDefault(v => v.ViewModel.GetType() == typeof(ViewModel_Project))?.ViewModel);
                var myproject = mostRecentProjectTreeViewModel?.ProjectList ?? new ObservableCollection<Projects>(new[] { new Projects() { Name = "Default Project"}});

                ChildViewModels.Add(new ChildControl("Tree View", new ViewModel_TreeView(new ObservableCollection<Projects>(myproject))));
                SelectedChildViewModel = ChildViewModels.Last();
            }));

        private RelayCommand projectSummary;
        public RelayCommand ProjectSummary => projectSummary ?? (projectSummary = new RelayCommand(
            () =>
            {
                ChildViewModels.Add(new ChildControl("Project Summary", new ViewModel_ProjectSummary()));
                SelectedChildViewModel = ChildViewModels.Last();
            }));


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
