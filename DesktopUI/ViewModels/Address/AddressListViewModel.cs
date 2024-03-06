using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Events.Main;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Address
{
    public class AddressListViewModel : AllViewModel<Domain.Address>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IAddressService _service;


        public AddressListViewModel(IEventAggregator eventAggregator) : base()
        {
            _eventAggregator = eventAggregator;
            _service = new AddressService(Context);
            DisplayName = "Adresy";
        }

        protected override async Task EditItem()
        {
            _eventAggregator.GetEvent<AddressItemOpened>().Publish(CurrentItem);
        }

        protected override async Task AddItem()
        {
            _eventAggregator.GetEvent<AddressItemOpened>().Publish(new Domain.Address());
        }

        protected override async Task LoadItem()
        {

        }


        protected override async Task DeleteItem()
        {
            await _service.Delete(CurrentItem.Id);
            await LoadList();
        }


        protected override async Task LoadList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Address>(await _service.GetAllAsync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }
    }
}
