using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using System.Text.RegularExpressions;

namespace Lokata.Mobile.Legacy.ViewModels.AddressViewModels
{
    public class AddressNewViewModel : ANewItemViewModel<Address>
    {
        private string _fullName;
        private string _street;
        private string _number;
        private string _postalCode;
        private string _postalPlace;

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public string Street
        {
            get => _street;
            set => SetProperty(ref _street, value);
        }

        public string Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        public string PostalCode
        {
            get => _postalCode;
            set => SetProperty(ref _postalCode, value);
        }

        public string PostalPlace
        {
            get => _postalPlace;
            set => SetProperty(ref _postalPlace, value);
        }

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(_number))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(_postalCode))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(_postalPlace))
            {
                return false;
            }
            var result = Regex.Match(_postalCode, @"^[0-9]{2}-[0-9]{3}$");
            if (!result.Success)
            {
                return false;
            }

            return true;
        }

        public override Address SetItem()
        {
            return new Address().CopyProperties(this);
        }
    }
}
