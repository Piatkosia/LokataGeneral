using Lokata.Mobile.Legacy.ViewModels.CategoryViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CategoryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryEditPage : ContentPage
    {
        private CategoryEditViewModel viewModel;
        public CategoryEditPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryEditViewModel();
        }
    }
}