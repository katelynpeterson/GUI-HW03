using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KPeterson_HW03.ViewModel
{
    class AddProjectCommand :ICommand
    {
         private ObservableCollection<Projects> project;

            public AddProjectCommand(ObservableCollection<Projects> project)
            {
                this.project = project;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
            project.Add(new Projects()
                {
                    Name = "New Project",
                    StartDate = DateTime.Today
                });
            }
        }
    
}
