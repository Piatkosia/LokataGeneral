using Lokata.Mobile.Legacy.ViewModels.CategoryViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CategoryViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryNewPage : ContentPage
    {
        private CategoryNewViewModel viewModel;
        public CategoryNewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoryNewViewModel();
        }
    }
}