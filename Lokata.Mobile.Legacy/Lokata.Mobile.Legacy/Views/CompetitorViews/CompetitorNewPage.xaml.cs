using Lokata.Mobile.Legacy.ViewModels.CompetitorViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitorViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitorNewPage : ContentPage
    {
        private CompetitorNewViewModel _viewModel;
        public CompetitorNewPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CompetitorNewViewModel();
        }
    }
}