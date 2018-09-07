using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace KPeterson_HW03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch = new Stopwatch();
        TimeSpan ts = new TimeSpan();
        string elapsedTime = "";
        DateTime today = DateTime.Today;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TimeCatcher_myTime.txt";

        List<String> list = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_time(object sender, RoutedEventArgs e)
        {
            current_time.Text = "start";
            stopwatch.Start();
            
        }

        private void print_time()
        {
            ts = stopwatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            current_time.Text = elapsedTime;
        }

        private void stop_time(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            current_time.Text = "Stop";
        }

        private void submit_time(object sender, RoutedEventArgs e)
        {
            if (stopwatch.Elapsed != null)
            {
                ts = stopwatch.Elapsed;

                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
                
                list.Add(today.ToString("MM/dd/yyyy") + " " + elapsedTime);

                stopwatch.Reset();
                current_time.Text = String.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            }
        }

        private void add_new_project(object sender, RoutedEventArgs e)
        {
            Size size = new Size(80, 80);
            Rect rect = new Rect(size);
            Button button = new Button();

            if (btn01.Visibility == Visibility.Collapsed)
                btn01.Visibility = Visibility.Visible;

            }

        private void delete_project(object sender, RoutedEventArgs e)
        {
            btn01.Visibility = Visibility.Collapsed;
        }

        private void view_report(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path))
                read_report.Text = File.ReadAllText(path);
            else
                read_report.Text = "File must be downloaded first";
        }

        private void share_report(object sender, RoutedEventArgs e)
        {
            DialogWindow window = new DialogWindow();
            window.Show();
        }

        private void download_report(object sender, RoutedEventArgs e)
        {
            foreach (String items in list) {
                File.AppendAllLines(path, new[] { items });
            }
        }

        private void btn01_click(object sender, RoutedEventArgs e)
        {
            current_project.Text = Project01.Text;
        }

        private void btn02_click(object sender, RoutedEventArgs e)
        {
            current_project.Text = Project02.Text;
        }
    }
}
