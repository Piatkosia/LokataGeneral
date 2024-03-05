using System.Text.RegularExpressions;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Address;
using Lokata.Domain.Services;
using Lokata.Utils;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Address
{
    public class AddAddressViewModel : SingleViewModel<Domain.Address>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IAddressService _service;

        public string FullName
        {
            get => CurrentItem.FullName;
            set
            {
                CurrentItem.FullName = value;
                OnPropertyChanged();
            }
        }

        public string Street
        {
            get => CurrentItem.Street;
            set
            {
                CurrentItem.Street = value;
                OnPropertyChanged();
            }
        }

        public string Number
        {
            get => CurrentItem.Number;
            set
            {
                CurrentItem.Number = value;
                OnPropertyChanged();
            }
        }

        public string PostalCode
        {
            get => CurrentItem.PostalCode;
            set
            {
                CurrentItem.PostalCode = value;
                OnPropertyChanged();
            }
        }

        public string PostalPlace
        {
            get => CurrentItem.PostalPlace;
            set
            {
                CurrentItem.PostalPlace = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get => CurrentItem.Id;
            set
            {
                CurrentItem.Id = value;
                OnPropertyChanged();
            }
        }

        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Number))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(PostalCode))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(PostalPlace))
            {
                return false;
            }
            var result = Regex.Match(PostalCode, @"^[0-9]{2}-[0-9]{3}$");
            if (!result.Success)
            {
                return false;
            }

            return true;
        }

        protected override void Save()
        {
            if (CurrentItem.Id == 0)
            {
                _service.Create(CurrentItem);
            }
            else
            {
                _service.Update(CurrentItem);
            }
            _eventAggregator.GetEvent<AddressSaved>().Publish(CurrentItem);
        }
        public AddAddressViewModel(IEventAggregator eventAggregator, Domain.Address address)
        {
            _eventAggregator = eventAggregator;
            _service = new AddressService(Context);
            DisplayName = "Nowy adres";
            CachedItem = (new Domain.Address()).CopyProperties(address);
            CurrentItem = address;
        }
    }
}
