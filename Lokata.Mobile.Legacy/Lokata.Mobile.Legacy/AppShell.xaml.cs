using Lokata.Mobile.Legacy.Views;
using Lokata.Mobile.Legacy.Views.AddressViews;
using Lokata.Mobile.Legacy.Views.SexViews;
using Lokata.Mobile.Legacy.Views.UmpireViews;
using System;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddressDetailsPage), typeof(AddressDetailsPage));
            Routing.RegisterRoute(nameof(AddressNewPage), typeof(AddressNewPage));
            Routing.RegisterRoute(nameof(AddressEditPage), typeof(AddressEditPage));
            Routing.RegisterRoute(nameof(AddressPage), typeof(AddressPage));
            Routing.RegisterRoute(nameof(PdfPage), typeof(PdfPage));
            Routing.RegisterRoute(nameof(UmpireDetailsPage), typeof(UmpireDetailsPage));
            Routing.RegisterRoute(nameof(UmpireNewPage), typeof(UmpireNewPage));
            Routing.RegisterRoute(nameof(UmpireEditPage), typeof(UmpireEditPage));
            Routing.RegisterRoute(nameof(UmpirePage), typeof(UmpirePage));
            Routing.RegisterRoute(nameof(SexPage), typeof(SexPage));
            Routing.RegisterRoute(nameof(SexDetailsPage), typeof(SexDetailsPage));
            Routing.RegisterRoute(nameof(SexNewPage), typeof(SexNewPage));
            Routing.RegisterRoute(nameof(SexEditPage), typeof(SexEditPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
