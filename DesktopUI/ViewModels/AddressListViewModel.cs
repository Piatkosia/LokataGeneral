using Lokata.DataService;
using Lokata.Domain;
using Lokata.Domain.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Lokata.DesktopUI.ViewModels
{
    public class AddressViewModel : WorkspaceViewModel
    {
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

        public AddressViewModel()
        {
            _service = new AddressService(Context);
            DisplayName = "Adresy";
            CurrentItem = new Address();
            LoadAddressList();
        }

        private async Task LoadAddressList()
        {
            AddressList = new ObservableCollection<Address>(await _service.GetAllAsync());
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
        //public DelegateCommand OpenItemCommand { get; set; }
    }
}
