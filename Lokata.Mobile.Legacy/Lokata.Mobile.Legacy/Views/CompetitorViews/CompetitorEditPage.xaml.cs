using Lokata.Mobile.Legacy.ViewModels.CompetitorViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitorViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitorEditPage : ContentPage
    {
        private CompetitorEditViewModel _viewModel;
        public CompetitorEditPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CompetitorEditViewModel();
        }
    }
}