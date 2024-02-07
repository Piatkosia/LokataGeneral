using Lokata.Mobile.Legacy.ViewModels.AddressViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressDetailsPage : ContentPage
    {
        AddressDetailsViewModel viewModel;
        public AddressDetailsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddressDetailsViewModel();
        }
    }
}