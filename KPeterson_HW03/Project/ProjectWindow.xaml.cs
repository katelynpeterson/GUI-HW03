using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KPeterson_HW03
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        ComboBox box = new ComboBox();
        ComboBoxItem item = new ComboBoxItem();

        ViewModel_Project project = new ViewModel_Project();
        public ProjectWindow()
        {
            InitializeComponent();
            //ProjectTypesArray();
        }

        private void menuClick_about(object sender, RoutedEventArgs e)
        {
            
            if(about_text.Visibility == Visibility.Visible) {
                about_text.Visibility = Visibility.Collapsed;
            }
            else
            about_text.Visibility = Visibility.Visible;
        }

        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void addNewType_handler(object sender, RoutedEventArgs e)
        {
            if (add_new_option.Text.Equals("") || add_new_option.Text.Equals(null))
            {
                ToolTip="Cannot add an empty project type";
            }
            else
            {
                TypeSelector.Items.Add(add_new_option.Text);
                //AddNewProjectType(add_new_option.Text);
                add_new_option.Clear();
            }
        }
        

        //private void ProjectTypesArray()
        //{

        //    box.Name = "TypeSelector";
        //    box.Width = 50;
        //    box.Items.Add("Client");
        //    box.Items.Add("Personal");
        //    box.Items.Add("School");
        //    //RootLayout.Children.Add(box);
        //}

        //public void AddNewProjectType(string newItem)
        //{
        //    box.Items.Add(newItem);
        //}
    }
}
