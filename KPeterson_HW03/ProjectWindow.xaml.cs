using System.Windows;
using System.Windows.Input;

namespace KPeterson_HW03
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        public ProjectWindow()
        {
            InitializeComponent();
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
    }
}
