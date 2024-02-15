using Lokata.Mobile.Legacy.ViewModels.CompetitorViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitorViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitorDetailsPage : ContentPage
    {
        private CompetitorDetailsViewModel viewModel;
        public CompetitorDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CompetitorDetailsViewModel();
        }
    }
}