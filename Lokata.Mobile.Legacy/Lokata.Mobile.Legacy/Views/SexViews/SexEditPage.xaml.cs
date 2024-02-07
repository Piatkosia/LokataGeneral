using Lokata.Mobile.Legacy.ViewModels.SexViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.SexViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SexEditPage : ContentPage
    {
        private SexEditViewModel viewModel;
        public SexEditPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SexEditViewModel();
        }
    }
}