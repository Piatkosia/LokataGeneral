using Lokata.Mobile.Legacy.ViewModels.PlaceViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.PlaceViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceDetailsPage : ContentPage
    {
        private PlaceDetailsViewModel _viewModel;
        public PlaceDetailsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PlaceDetailsViewModel();
        }
    }
}