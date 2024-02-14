using Lokata.Mobile.Legacy.ViewModels.CompetitionViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitionViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionPage : ContentPage
    {
        private CompetitionViewModel viewModel;
        public CompetitionPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CompetitionViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}