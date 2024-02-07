using Lokata.Mobile.Legacy.ViewModels.SexViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.SexViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SexPage : ContentPage
    {
        private SexViewModel ViewModel
        {
            get { return BindingContext as SexViewModel; }
            set { BindingContext = value; }
        }

        public SexPage()
        {
            InitializeComponent();
            ViewModel = new SexViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}