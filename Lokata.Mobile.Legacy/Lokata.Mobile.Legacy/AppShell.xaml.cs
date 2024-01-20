using Lokata.Mobile.Legacy.ViewModels;
using Lokata.Mobile.Legacy.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
