using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.PlaceViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.PlaceViewModels
{
    public class PlaceDetailsViewModel : ADetailsViewModel<Place>
    {
        private string _name;
        private int? _address;
        private int? _shootingPlacesCount;
        private Address _addressNavigation = new Address();

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int? Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public int? ShootingPlacesCount
        {
            get => _shootingPlacesCount;
            set => SetProperty(ref _shootingPlacesCount, value);
        }

        public virtual Address AddressNavigation
        {
            get => _addressNavigation;
            set => SetProperty(ref _addressNavigation, value);
        }

        public override async void SetItemProperties(Place item)
        {
            this.CopyProperties(item);
            var datastore = new AddressDataStore();

            if (item.Address != null)
            {
                await datastore.Refresh();
                AddressNavigation = await datastore.GetItemAsync(item.Address.Value);
            }
        }

        protected override async void OnEditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(PlaceEditPage)}?{nameof(PlaceEditViewModel.ItemId)}={Id}");
        }
    }
}
