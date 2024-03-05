using System.Windows.Input;

using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Helpers;

using Prism.Events;

namespace Lokata.DesktopUI.UserControlsModels
{
    public class MenuBarModel
    {
        private readonly IEventAggregator _eventAggregator;
        public ICommand AddressCommand { get; set; }

        public MenuBarModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            AddressCommand = new BaseCommand(OnAddress);
        }

        private void OnAddress()
        {
            _eventAggregator.GetEvent<AddressListOpened>().Publish();
        }
    }
}
