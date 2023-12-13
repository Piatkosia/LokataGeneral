using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokata.DesktopUI.ViewModels
{
    public class AddressViewModel : WorkspaceViewModel
    {
        private string _fullName;
        private string _street;
        private string _number;
        private string _postalCode;
        private string _postalPlace;

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

        public string Street
        {
            get => _street;
            set
            {
                _street = value;
                OnPropertyChanged();
            }
        }

        public string Number
        {
            get => _number;
            set
            {
                _number = value; 
                OnPropertyChanged();
            }
        }

        public string PostalCode
        {
            get => _postalCode;
            set
            {
                _postalCode = value;
                OnPropertyChanged();
            }
        }

        public string PostalPlace
        {
            get => _postalPlace;
            set
            {
                _postalPlace = value;
                OnPropertyChanged();
            }
        }
    }
}
