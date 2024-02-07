using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views;
using Lokata.Mobile.Legacy.Views.AddressViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.AddressViewModels
{
    public class AddressViewModel : AListViewModel<Address>
    {
        public AddressViewModel() : base("Adres")
        {
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(AddressNewPage));
        }

        protected override async void OnDelete(Address item)
        {
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        protected override async void OnEditAsync(Address item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(AddressEditPage)}?{nameof(AddressEditViewModel.ItemId)}={item.Id}");
        }

        protected override async void OnItemSelected(Address item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(AddressDetailsPage)}?{nameof(AddressDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
