using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.CompetitionViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.CompetitionViewModels
{
    public class CompetitionViewModel : AListViewModel<Competition>
    {
        public CompetitionViewModel() : base("Konkurencja")
        {
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(CompetitionNewPage));
        }

        protected override async void OnDelete(Competition item)
        {
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        protected override async void OnEditAsync(Competition item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(CompetitionEditPage)}?{nameof(CompetitionEditViewModel.ItemId)}={item.Id}");
        }

        protected override async void OnItemSelected(Competition item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(CompetitionDetailsPage)}?{nameof(CompetitionDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
