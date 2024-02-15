using Lokata.Mobile.Legacy.ViewModels.PlaceViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.PlaceViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlacePage : ContentPage
    {
        private readonly PlaceViewModel _viewModel;
        public PlacePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PlaceViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}