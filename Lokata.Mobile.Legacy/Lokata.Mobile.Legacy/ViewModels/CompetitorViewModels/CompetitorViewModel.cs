using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.CompetitorViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.CompetitorViewModels
{
    public class CompetitorViewModel : AListViewModel<Competitor>
    {
        public CompetitorViewModel() : base("Uczestnik")
        {
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(CompetitorNewPage));
        }

        protected override async void OnDelete(Competitor item)
        {
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        protected override async void OnEditAsync(Competitor item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(CompetitorEditPage)}?{nameof(CompetitorEditViewModel.ItemId)}={item.Id}");
        }

        protected override async void OnItemSelected(Competitor item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(CompetitorDetailsPage)}?{nameof(CompetitorDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
