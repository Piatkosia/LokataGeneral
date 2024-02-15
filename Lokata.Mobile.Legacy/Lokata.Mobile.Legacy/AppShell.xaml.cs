using Lokata.Mobile.Legacy.Views;
using Lokata.Mobile.Legacy.Views.AddressViews;
using Lokata.Mobile.Legacy.Views.CategoryViews;
using Lokata.Mobile.Legacy.Views.CompetitionViews;
using Lokata.Mobile.Legacy.Views.CompetitorViews;
using Lokata.Mobile.Legacy.Views.PlaceViews;
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
            Routing.RegisterRoute(nameof(CategoryDetailsPage), typeof(CategoryDetailsPage));
            Routing.RegisterRoute(nameof(CategoryNewPage), typeof(CategoryNewPage));
            Routing.RegisterRoute(nameof(CategoryEditPage), typeof(CategoryEditPage));
            Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
            Routing.RegisterRoute(nameof(CompetitionDetailsPage), typeof(CompetitionDetailsPage));
            Routing.RegisterRoute(nameof(CompetitionNewPage), typeof(CompetitionNewPage));
            Routing.RegisterRoute(nameof(CompetitionEditPage), typeof(CompetitionEditPage));
            Routing.RegisterRoute(nameof(CompetitionPage), typeof(CompetitionPage));
            Routing.RegisterRoute(nameof(PlaceDetailsPage), typeof(PlaceDetailsPage));
            Routing.RegisterRoute(nameof(PlaceNewPage), typeof(PlaceNewPage));
            Routing.RegisterRoute(nameof(PlaceEditPage), typeof(PlaceEditPage));
            Routing.RegisterRoute(nameof(PlacePage), typeof(PlacePage));
            Routing.RegisterRoute(nameof(CompetitorDetailsPage), typeof(CompetitorDetailsPage));
            Routing.RegisterRoute(nameof(CompetitorNewPage), typeof(CompetitorNewPage));
            Routing.RegisterRoute(nameof(CompetitorEditPage), typeof(CompetitorEditPage));
            Routing.RegisterRoute(nameof(CompetitorPage), typeof(CompetitorPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
