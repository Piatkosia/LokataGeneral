using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.UmpireViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.UmpireViewModels
{
    internal class UmpireViewModel : AListViewModel<Umpire>

    {
        public UmpireViewModel() : base("Sędzia")
        {

        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(UmpireNewPage));
        }

        protected override async void OnDelete(Umpire item)
        {
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        protected override async void OnEditAsync(Umpire item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(UmpireEditPage)}?{nameof(UmpireEditViewModel.ItemId)}={item.Id}");
        }

        protected override async void OnItemSelected(Umpire item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(UmpireDetailsPage)}?{nameof(UmpireDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
