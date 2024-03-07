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


        public AddressListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new AddressService(Context);
            DisplayName = "Adresy";
            _eventAggregator.GetEvent<AddressSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Address obj)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Address>(_service.GetAll());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override void EditItem()
        {
            _eventAggregator.GetEvent<AddressItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<AddressItemOpened>().Publish(null);
        }

        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<AddressListAsExcelSaved>().Publish();
        }
        protected override void SaveAsPdf()
        {
            _eventAggregator.GetEvent<AddressListAsPdfSaved>().Publish();
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
