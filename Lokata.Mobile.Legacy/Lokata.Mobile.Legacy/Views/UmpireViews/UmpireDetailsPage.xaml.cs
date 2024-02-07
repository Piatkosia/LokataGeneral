using Lokata.Mobile.Legacy.ViewModels.UmpireViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.UmpireViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UmpireDetailsPage : ContentPage
    {
        private UmpireDetailsViewModel viewModel;
        public UmpireDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UmpireDetailsViewModel();
        }
    }
}