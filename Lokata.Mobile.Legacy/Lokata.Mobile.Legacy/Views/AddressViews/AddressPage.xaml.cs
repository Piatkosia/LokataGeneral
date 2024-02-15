using Lokata.Mobile.Legacy.ViewModels.AddressViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.AddressViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPage : ContentPage
    {
        public AddressViewModel ViewModel
        {
            get { return BindingContext as AddressViewModel; }
            set { BindingContext = value; }
        }
        public AddressPage()
        {
            InitializeComponent();
            BindingContext = new AddressViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}