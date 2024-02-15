using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.ViewModels.PlaceViewModels
{
    public class PlaceEditViewModel : AEditItemViewModel<Place>
    {
        private string _name;
        private int? _address;
        private int? _shootingPlacesCount;
        private Address _addressNavigation = new Address();
        private ObservableCollection<Address> _addressList = new ObservableCollection<Address>();
        private Address _selectedAddress = null;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int? Address
        {
            get => _address;
            set
            {
                SetProperty(ref _address, value);
                if (AddressList.Any())
                {
                    SelectedAddress = AddressList.FirstOrDefault(x => x.Id == Address);
                }
            }
        }

        public int? ShootingPlacesCount
        {
            get => _shootingPlacesCount;
            set => SetProperty(ref _shootingPlacesCount, value);
        }

        public virtual Address SelectedAddress
        {
            get => _selectedAddress;
            set => SetProperty(ref _selectedAddress, value);
        }

        public ObservableCollection<Address> AddressList
        {
            get => _addressList;
            set => SetProperty(ref _addressList, value);
        }

        private async Task AssignAddressList()
        {
            var datastore = new AddressDataStore();
            await datastore.Refresh();
            var items = await datastore.GetItemsAsync(true);
            AddressList = new ObservableCollection<Address>(items);
            SelectedAddress = AddressList.FirstOrDefault(x => x.Id == Address);
        }

        public override async void SetItemProperties(Place item)
        {
            this.CopyProperties(item);
            await AssignAddressList();
        }

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return false;
            }

            if (ShootingPlacesCount < 0)
            {
                return false;
            }

            if (SelectedAddress == null)
            {
                return false;
            }
            return true;
        }

        public override Place SetItem()
        {
            var result = new Place().CopyProperties(this);
            result.Address = SelectedAddress.Id;
            return result;
        }
    }
}
