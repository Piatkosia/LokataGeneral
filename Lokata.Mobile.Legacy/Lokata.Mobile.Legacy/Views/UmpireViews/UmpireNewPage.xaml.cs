using Lokata.Mobile.Legacy.ViewModels.UmpireViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.UmpireViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UmpireNewPage : ContentPage
    {
        private UmpireNewViewModel viewModel;
        public UmpireNewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UmpireNewViewModel();
        }
    }
}