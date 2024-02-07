using Lokata.Mobile.Legacy.ViewModels.SexViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.SexViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SexDetailsPage : ContentPage
    {
        SexDetailsViewModel viewModel;
        public SexDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SexDetailsViewModel();
        }
    }
}