using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;

using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Events.Main;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels
{
    public class MainWindowViewModel : Observable
    {
        private readonly IEventAggregator _eventAggregator;
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<LoadStarted>().Subscribe(OnLoadStarted);
            _eventAggregator.GetEvent<LoadStopped>().Subscribe(OnLoadStopped);
            _eventAggregator.GetEvent<AddressOpened>().Subscribe(OnAddressOpened);
        }

        private void OnAddressOpened()
        {
            ShowWorkspace(new AddressViewModel(_eventAggregator), true);
        }

        private void OnLoadStarted()
        {
            IsLoading = true;
        }
        private void OnLoadStopped()
        {
            IsLoading = false;
        }

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get;
        } = new ObservableCollection<WorkspaceViewModel>();

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.RequestClose -= this.OnWorkspaceRequestClose;
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
                workspace.RequestClose += this.OnWorkspaceRequestClose;
            }

            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            CollectionViewSource.GetDefaultView(this.Workspaces)?.MoveCurrentTo(workspace);
        }
    }
}
