using Lokata.Mobile.Legacy.ViewModels.CategoryViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CategoryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailsPage : ContentPage
    {
        CategoryDetailsViewModel viewModel;
        public CategoryDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryDetailsViewModel();
        }
    }
}