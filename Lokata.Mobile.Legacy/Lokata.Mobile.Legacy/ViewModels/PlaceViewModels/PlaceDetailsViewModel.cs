using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;

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
            set => _name = value;
        }

        public int? Address
        {
            get => _address;
            set => _address = value;
        }

        public int? ShootingPlacesCount
        {
            get => _shootingPlacesCount;
            set => _shootingPlacesCount = value;
        }

        public virtual Address AddressNavigation
        {
            get => _addressNavigation;
            set => _addressNavigation = value;
        }

        public override async void SetItemProperties(Place item)
        {
            this.CopyProperties(item);
        }

        protected override void OnEditAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
