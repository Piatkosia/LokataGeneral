using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.UmpireViews;
using System;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.UmpireViewModels
{
    public class UmpireDetailsViewModel : ADetailsViewModel<Umpire>
    {
        private string _fullName;
        private string _permissionDocumentNumber;
        private DateTime? _permissionDocumentDate;
        private DateTime? _permissionValidUntil;

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public string PermissionDocumentNumber
        {
            get => _permissionDocumentNumber;
            set => SetProperty(ref _permissionDocumentNumber, value);
        }

        public DateTime? PermissionDocumentDate
        {
            get => _permissionDocumentDate;
            set => SetProperty(ref _permissionDocumentDate, value);
        }

        public DateTime? PermissionValidUntil
        {
            get => _permissionValidUntil;
            set => SetProperty(ref _permissionValidUntil, value);
        }

        public override void SetItemProperties(Umpire item)
        {
            this.CopyProperties(item);
            if (item.PermissionDocumentDate != null)
                PermissionDocumentDate = item.PermissionDocumentDate.Value.DateTime;
            if (item.PermissionValidUntil != null)
                PermissionValidUntil = item.PermissionValidUntil.Value.DateTime;
        }

        protected override async void OnEditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(UmpireEditPage)}?{nameof(UmpireEditViewModel.ItemId)}={Id}");
        }
    }
}
