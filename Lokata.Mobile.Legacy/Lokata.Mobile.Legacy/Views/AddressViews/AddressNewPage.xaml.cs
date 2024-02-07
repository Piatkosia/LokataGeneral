using Lokata.Mobile.Legacy.ViewModels.AddressViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.AddressViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressNewPage : ContentPage
    {
        private AddressNewViewModel viewModel;
        public AddressNewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddressNewViewModel();
        }
    }
}