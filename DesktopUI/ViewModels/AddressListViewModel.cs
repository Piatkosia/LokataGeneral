using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Main;
using Lokata.DesktopUI.Helpers;
using Lokata.Domain;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels
{
    public class AddressViewModel : WorkspaceViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        public Address CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Address> AddressList
        {
            get => _addressList;
            set
            {
                _addressList = value;
                OnPropertyChanged();
            }
        }

        private readonly IAddressService _service;
        private ObservableCollection<Address> _addressList;
        private Address _currentItem;

        public AddressViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new AddressService(Context);
            DisplayName = "Adresy";
            CurrentItem = new Address();
            DeleteCommand = new BaseCommand(async () => await DeleteItem());
            LoadCommand = new BaseCommand(async () => await LoadAddressList());
            AddCommand = new BaseCommand(async () => await AddItem());
            EditCommand = new BaseCommand(async () => await EditItem());
        }

        private async Task EditItem()
        {
            throw new System.NotImplementedException();
        }

        private async Task AddItem()
        {
            throw new System.NotImplementedException();
        }

        private async Task LoadItem()
        {

        }


        private async Task DeleteItem()
        {

        }


        private async Task LoadAddressList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            AddressList = new ObservableCollection<Address>(await _service.GetAllAsync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        public string FullName
        {
            get => CurrentItem.FullName;
            set
            {
                CurrentItem.FullName = value;
                OnPropertyChanged();
            }
        }

        public string Street
        {
            get => CurrentItem.Street;
            set
            {
                CurrentItem.Street = value;
                OnPropertyChanged();
            }
        }

        public string Number
        {
            get => CurrentItem.Number;
            set
            {
                CurrentItem.Number = value;
                OnPropertyChanged();
            }
        }

        public string PostalCode
        {
            get => CurrentItem.PostalCode;
            set
            {
                CurrentItem.PostalCode = value;
                OnPropertyChanged();
            }
        }

        public string PostalPlace
        {
            get => CurrentItem.PostalPlace;
            set
            {
                CurrentItem.PostalPlace = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => CurrentItem.Id;
            set
            {
                CurrentItem.Id = value;
                OnPropertyChanged();
            }
        }
    }
}
