using Lokata.Mobile.Legacy.ViewModels.PlaceViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.PlaceViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceEditPage : ContentPage
    {
        private readonly PlaceEditViewModel _viewModel;
        public PlaceEditPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PlaceEditViewModel();
        }
    }
}