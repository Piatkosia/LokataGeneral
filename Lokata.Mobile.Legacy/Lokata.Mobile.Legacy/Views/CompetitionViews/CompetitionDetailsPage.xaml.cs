using Lokata.Mobile.Legacy.ViewModels.CompetitionViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitionViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionDetailsPage : ContentPage
    {
        private CompetitionDetailsViewModel _viewModel;
        public CompetitionDetailsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CompetitionDetailsViewModel();
        }
    }
}