using Lokata.Mobile.Legacy.ViewModels.CategoryViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CategoryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        private CategoryViewModel viewModel;
        public CategoryPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}