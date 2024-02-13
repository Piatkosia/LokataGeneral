using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.SexViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.SexViewModels
{
    public class SexViewModel : AListViewModel<Sex>
    {
        public SexViewModel() : base("Płeć")
        {
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(SexNewPage));
        }

        protected override async void OnDelete(Sex item)
        {
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        protected override async void OnEditAsync(Sex item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(SexEditPage)}?{nameof(SexEditViewModel.ItemId)}={item.Id}");
        }

        protected override async void OnItemSelected(Sex item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(SexDetailsPage)}?{nameof(SexDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
