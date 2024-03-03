using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Command;
using Lokata.DesktopUI.Events.Main;
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
            DeleteCommand = new DelegateCommand(async (object o) => await DeleteItem(o));
            LoadCommand = new DelegateCommand(async (object o) => await LoadAddressList());
        }

        private async Task LoadItem(object o)
        {
            throw new System.NotImplementedException();
        }


        private async Task DeleteItem(object o)
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
