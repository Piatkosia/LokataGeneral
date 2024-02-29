using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

using Lokata.DesktopUI.ViewModels;

namespace Lokata.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<WorkspaceViewModel> _workspaces;

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        private void OnWorkspacesChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public MainWindow()
        {
            InitializeComponent();
            License.Text = Environment.UserName;
            AssignClocks();
            Menu.AddressClicked += Menu_AddressClicked;
        }

        private void Menu_AddressClicked(object sender, EventArgs e)
        {
            ((MainWindowViewModel)DataContext).ShowWorkspace(new AddressViewModel((MainWindowViewModel)DataContext),
                true);
        }

        private void AssignClocks()
        {
            Time.Text = DateTime.Now.ToString("HH:mm");
            var clock = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(1)
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
            Time.Text = DateTime.Now.ToString("HH:mm");
        }

        public void ShowWorkspace<T>(T workspaceViewModel, bool allowMulti = false)
        {
            var workspace = Workspaces.FirstOrDefault(vm => vm.GetType() == workspaceViewModel.GetType());

            if (workspace == null || allowMulti)
            {
                workspace = workspaceViewModel as WorkspaceViewModel;
                Workspaces.Add(workspace);
            }

            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            CollectionViewSource.GetDefaultView(this.Workspaces)?.MoveCurrentTo(workspace);
        }
    }
}
