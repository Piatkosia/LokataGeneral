using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.AddressViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.AddressViewModels
{
    public class AddressDetailsViewModel : ADetailsViewModel<Address>
    {
        private string _fullName;
        private string _street;
        private string _number;
        private string _postalCode;
        private string _postalPlace;
        public Address SelectedItem { get; set; }

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public string Street
        {
            get => _street;
            set => SetProperty(ref _street, value);
        }

        public string Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        public string PostalCode
        {
            get => _postalCode;
            set => SetProperty(ref _postalCode, value);
        }

        public string PostalPlace
        {
            get => _postalPlace;
            set => SetProperty(ref _postalPlace, value);
        }

        public override void SetItemProperties(Address item)
        {
            this.CopyProperties(item);
        }

        protected override async void OnEditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddressEditPage)}?{nameof(AddressEditViewModel.ItemId)}={Id}");
        }
    }
}
