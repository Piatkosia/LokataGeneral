using Lokata.Mobile.Legacy.ViewModels.Abstract;
using System;

namespace Lokata.Mobile.Legacy.ViewModels.UmpireViewModels
{
    internal class UmpireNewViewModel : ANewItemViewModel<Umpire>
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

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(_fullName))
            {
                return false;
            }
            return true;
        }

        public override Umpire SetItem()
        {
            return new Umpire
            {
                FullName = _fullName,
                PermissionDocumentNumber = _permissionDocumentNumber,
                PermissionDocumentDate = _permissionDocumentDate,
                PermissionValidUntil = _permissionValidUntil
            }; //because it has a problem with datetime

        }
    }
}
