using Lokata.Mobile.Legacy.ViewModels.UmpireViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.UmpireViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UmpireEditPage : ContentPage
    {
        private UmpireEditViewModel viewModel;
        public UmpireEditPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UmpireEditViewModel();
        }
    }
}