﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Events.Competition;
using Lokata.DesktopUI.Events.Main;
using Lokata.DesktopUI.Events.Umpire;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.ViewModels.Address;
using Lokata.DesktopUI.ViewModels.Competition;
using Lokata.DesktopUI.ViewModels.Umpire;

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

        public ICommand AddressCommand { get; set; }
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            AddEvents();
            AddressCommand = new BaseCommand(OnAddressListOpened);
        }

        private void AddEvents()
        {
            _eventAggregator.GetEvent<LoadStarted>().Subscribe(OnLoadStarted);
            _eventAggregator.GetEvent<LoadStopped>().Subscribe(OnLoadStopped);
            _eventAggregator.GetEvent<AddressListOpened>().Subscribe(OnAddressListOpened);
            _eventAggregator.GetEvent<AddressItemOpened>().Subscribe(OnAddAddressOpened);
            _eventAggregator.GetEvent<UmpireListOpened>().Subscribe(OnUmpireListOpened);
            _eventAggregator.GetEvent<UmpireItemOpened>().Subscribe(OnAddUmpireOpened);
            _eventAggregator.GetEvent<CompetitionListOpened>().Subscribe(OnCompetitionListOpened);
            _eventAggregator.GetEvent<CompetitionItemOpened>().Subscribe(OnAddCompetitionOpened);
        }

        private void OnAddCompetitionOpened(Domain.Competition obj)
        {
            ShowWorkspace(new CompetitionViewModel(_eventAggregator, obj), true);
        }

        private void OnCompetitionListOpened()
        {
            ShowWorkspace(new CompetitionListViewModel(_eventAggregator), false);
        }

        private void OnAddUmpireOpened(Domain.Umpire obj)
        {
            ShowWorkspace(new UmpireViewModel(_eventAggregator, obj), true);
        }

        private void OnUmpireListOpened()
        {
            ShowWorkspace(new UmpireListViewModel(_eventAggregator), false);
        }

        private void OnAddAddressOpened(Domain.Address address)
        {
            ShowWorkspace(new AddressViewModel(_eventAggregator, address), true);
        }

        private void OnAddressListOpened()
        {
            ShowWorkspace(new AddressListViewModel(_eventAggregator), false);
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
                new CommandViewModel("Adresy",new BaseCommand(OnAddressListOpened)),
                new CommandViewModel("Sędziowie",new BaseCommand(OnUmpireListOpened)),
                new CommandViewModel("Konkurencje",new BaseCommand(OnCompetitionListOpened))
            };
        }

        public void ShowWorkspace<T>(T workspaceViewModel, bool allowMulti = false)
        {
            WorkspaceViewModel workspace = null;
            if (!allowMulti && Workspaces.Any())
            {
                workspace = Workspaces.FirstOrDefault(vm => vm.GetType() == workspaceViewModel.GetType());
            }

            if (workspace == null || allowMulti)
            {
                workspace = workspaceViewModel as WorkspaceViewModel;
                workspace.RequestClose += this.OnWorkspaceRequestClose;
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
