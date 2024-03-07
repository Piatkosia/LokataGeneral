﻿using System.Windows.Input;

using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Events.Umpire;
using Lokata.DesktopUI.Helpers;

using Prism.Events;

namespace Lokata.DesktopUI.UserControlsModels
{
    public class MenuBarModel
    {
        private readonly IEventAggregator _eventAggregator;
        public ICommand AddressCommand { get; set; }
        public ICommand UmpireCommand { get; set; }

        public MenuBarModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            AddressCommand = new BaseCommand(OnAddress);
            UmpireCommand = new BaseCommand(OnUmpire);
        }

        private void OnUmpire()
        {
            _eventAggregator.GetEvent<UmpireListOpened>().Publish();
        }

        private void OnAddress()
        {
            _eventAggregator.GetEvent<AddressListOpened>().Publish();
        }
    }
}
