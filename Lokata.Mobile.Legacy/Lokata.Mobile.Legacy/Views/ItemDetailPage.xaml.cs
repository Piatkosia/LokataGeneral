using Lokata.Mobile.Legacy.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}