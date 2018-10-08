
using System.Windows;
using System.Windows.Input;

namespace KPeterson_HW03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();


        }

        private void CloseCommandHandler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
