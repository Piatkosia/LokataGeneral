using Lokata.DesktopUI;
using Lokata.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow();
            var viewModel = new MainWindowViewModel();
            window.DataContext = viewModel;
            MainWindow = window;
            window.Show();
        }
    }
}
