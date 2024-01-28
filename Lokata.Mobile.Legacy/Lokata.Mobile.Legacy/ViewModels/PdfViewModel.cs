using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels
{
    public class PdfViewModel : BaseViewModel
    {
        public PdfViewModel()
        {
            Title = "Pobierz PDF";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("http://192.168.193.3:5090/api/Competitor/pdf"));
        }

        public ICommand OpenWebCommand { get; }
    }
}