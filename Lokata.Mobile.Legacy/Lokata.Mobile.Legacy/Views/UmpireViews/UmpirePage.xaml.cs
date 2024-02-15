using Lokata.Mobile.Legacy.ViewModels.UmpireViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.UmpireViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UmpirePage : ContentPage
    {
        private UmpireViewModel _viewModel;
        public UmpirePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UmpireViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}