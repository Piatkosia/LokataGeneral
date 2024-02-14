using Lokata.Mobile.Legacy.ViewModels.CompetitionViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.CompetitionViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionEditPage : ContentPage
    {
        private CompetitionEditViewModel _viewModel;
        public CompetitionEditPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CompetitionEditViewModel();
        }
    }
}