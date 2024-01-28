using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Data;

namespace Lokata.DesktopUI.ViewModels
{
    internal class MainWindowViewModel : Observable
    {
        private bool _isLoading = true;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
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

        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            this.Workspaces.Remove(workspace);
        }

        private ReadOnlyCollection<CommandViewModel> _commands { get; set; }
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    var commands = InitListCommands();
                    _commands = new ReadOnlyCollection<CommandViewModel>(commands);
                }
                return _commands;
            }
        }

        private IList<CommandViewModel> InitListCommands()
        {
            return new List<CommandViewModel>
            {

            };
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
