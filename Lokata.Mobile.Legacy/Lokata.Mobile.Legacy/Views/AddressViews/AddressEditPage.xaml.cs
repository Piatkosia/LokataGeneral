using Lokata.Mobile.Legacy.ViewModels.AddressViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.AddressViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressEditPage : ContentPage
    {
        private AddressEditViewModel viewModel;
        public AddressEditPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddressEditViewModel();
        }
    }
}