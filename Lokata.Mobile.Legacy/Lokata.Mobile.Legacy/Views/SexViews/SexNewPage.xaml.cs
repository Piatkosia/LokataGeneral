using Lokata.Mobile.Legacy.ViewModels.SexViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lokata.Mobile.Legacy.Views.SexViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SexNewPage : ContentPage
    {
        private SexNewViewModel viewModel;
        public SexNewPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SexNewViewModel();
        }
    }
}