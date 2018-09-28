using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        //Timing buttons
        private void start_time(object sender, RoutedEventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                current_time.Text = "Start";
                stopwatch.Start();
            }            
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
   
        //Project Buttons
        private void add_new_project(object sender, RoutedEventArgs e)
        {
            if (btn01.Visibility == Visibility.Collapsed)
                btn01.Visibility = Visibility.Visible;
        }

        private void delete_project(object sender, RoutedEventArgs e)
        {
            btn01.Visibility = Visibility.Collapsed;
        }

        private void view_report(object sender, RoutedEventArgs e)
        {
            DialogWindow window = new DialogWindow();
            window.Show();
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

        //Display current project name as title
        private void btn01_click(object sender, RoutedEventArgs e)
        {
            current_project.Text = Project01.Text;
            ProjectWindow project = new ProjectWindow();
            project.Show();
        }

        private void btn02_click(object sender, RoutedEventArgs e)
        {
            current_project.Text = Project02.Text;
            ProjectWindow project = new ProjectWindow();
            project.Show();
        }

        private void btn03_click(object sender, RoutedEventArgs e)
        {
            current_project.Text = Project03.Text;
            ProjectWindow project = new ProjectWindow();
            project.Show();
        }

        private void btn04_click(object sender, RoutedEventArgs e)
        {
            current_project.Text = Project04.Text;
            ProjectWindow project = new ProjectWindow();
            project.Show();
        }

        private void btn05_click(object sender, RoutedEventArgs e)
        {
            current_project.Text = Project05.Text;
            ProjectWindow project = new ProjectWindow();
            project.Show();
        }

        //Control start and stop with spacebar, Ctrl+N adds new project
        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            //Add a new project button
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && (e.Key == Key.N || e.SystemKey == Key.N))
            {
                if (btn01.Visibility == Visibility.Collapsed)
                    btn01.Visibility = Visibility.Visible;
            }

            //Start the stopwatch if not already running
            if ((e.Key == Key.Space || e.SystemKey == Key.Space) && !stopwatch.IsRunning)
            {
                current_time.Text = "Start";
                stopwatch.Start();
            }
            else if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                current_time.Text = "Stop";
            }
            base.OnKeyDown(e);
        }

        //Right click opens a new window
        void MouseRightButtonDown_Info(object sender, MouseButtonEventArgs e)
        {
            var window = new DialogWindow();
            window.Content = "Hello user who clicked the right mouse button!";
            window.Show();
        }

        
    }
}
