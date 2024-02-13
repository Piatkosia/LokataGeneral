using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.CategoryViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.CategoryViewModels
{
    public class CategoryViewModel : AListViewModel<Category>
    {
        public CategoryViewModel() : base("Kategoria")
        {

        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(CategoryNewPage));
        }

        protected override async void OnDelete(Category item)
        {
            await DataStore.DeleteItemAsync(item.Id);
            await ExecuteLoadItemsCommand();
        }

        protected override async void OnEditAsync(Category item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(CategoryEditPage)}?{nameof(CategoryEditViewModel.ItemId)}={item.Id}");
        }

        protected override async void OnItemSelected(Category item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(CategoryDetailsPage)}?{nameof(CategoryDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}
