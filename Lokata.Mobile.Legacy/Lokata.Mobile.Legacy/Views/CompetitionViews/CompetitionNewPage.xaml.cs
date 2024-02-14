using Lokata.Mobile.Legacy.ViewModels.CompetitionViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitionViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionNewPage : ContentPage
    {
        private CompetitionNewViewModel _viewModel;
        public CompetitionNewPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CompetitionNewViewModel();
        }
    }
}