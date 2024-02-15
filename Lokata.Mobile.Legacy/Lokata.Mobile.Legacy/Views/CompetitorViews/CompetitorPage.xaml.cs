using Lokata.Mobile.Legacy.ViewModels.CompetitorViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitorViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitorPage : ContentPage
    {
        private CompetitorViewModel _viewModel;
        public CompetitorPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CompetitorViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}