using Lokata.DesktopUI.ViewModels;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Lokata.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            License.Text = Environment.UserName;
            AssignClocks();
        }

        private void AssignClocks()
        {
            var clock = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            clock.Tick += LiveTime_Tick;
            clock.Start();
            var clock2 = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            clock2.Tick += StopLoading;
            clock2.Start();
        }
        private void StopLoading(object sender, EventArgs e)
        {
            ((MainWindowViewModel)DataContext).IsLoading = false;
            ((DispatcherTimer)sender).Stop();
        }

        private void LiveTime_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
