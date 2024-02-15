using Lokata.Mobile.Legacy.ViewModels.PlaceViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.PlaceViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceNewPage : ContentPage
    {
        private readonly PlaceNewViewModel _viewModel;
        public PlaceNewPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PlaceNewViewModel();
        }
    }
}