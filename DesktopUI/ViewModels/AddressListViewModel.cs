using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Command;
using Lokata.Domain;
using Lokata.Domain.Services;

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

        public AddressViewModel(MainWindowViewModel parent)
        {
            _service = new AddressService(Context);
            DisplayName = "Adresy";
            CurrentItem = new Address();
            DeleteCommand = new DelegateCommand(async (object o) => await DeleteItem(o));
            Parent = parent;
            LoadAddressList();
        }

        public MainWindowViewModel Parent { get; set; }

        private async Task DeleteItem(object o)
        {

        }


        private async Task LoadAddressList()
        {
            Parent.IsLoading = true;
            AddressList = new ObservableCollection<Address>(await _service.GetAllAsync());
            Parent.IsLoading = false;
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
        public DelegateCommand LoadCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

    }
}
