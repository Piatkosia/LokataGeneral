using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.PlaceViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.PlaceViewModels
{
    public class PlaceViewModel : AListViewModel<Place>
    {
        public PlaceViewModel() : base("Miejsce")
        {
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(PlaceNewPage));
        }

        protected override async void OnDelete(Place item)
        {
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        protected override async void OnEditAsync(Place item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(PlaceEditPage)}?{nameof(PlaceEditViewModel.ItemId)}={item.Id}");
        }

        protected override async void OnItemSelected(Place item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(PlaceDetailsPage)}?{nameof(PlaceDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
