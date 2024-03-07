using Lokata.DataService;
using Lokata.DesktopUI.Events.Address;
using Lokata.Domain.Services;
using Lokata.Utils;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Address
{
    public class AddressViewModel : SingleViewModel<Domain.Address>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IAddressService _service;

        public string FullName
        {
            get => CurrentItem.FullName;
            set
            {
                CurrentItem.FullName = value;
                RaiseOnPropertyChanged();
                DisplayName = value;
            }
        }

        public bool FullNameIsChanged => CachedItem.FullName != CurrentItem.FullName;

        public string FullNameOriginalValue => CachedItem.FullName;

        public string Street
        {
            get => CurrentItem.Street;
            set
            {
                CurrentItem.Street = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool StreetIsChanged => CachedItem.Street != CurrentItem.Street;

        public string StreetOriginalValue => CachedItem.Street;

        public string Number
        {
            get => CurrentItem.Number;
            set
            {
                CurrentItem.Number = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool NumberIsChanged => CachedItem.Number != CurrentItem.Number;

        public string NumberOriginalValue => CachedItem.Number;

        public string PostalCode
        {
            get => CurrentItem.PostalCode;
            set
            {
                CurrentItem.PostalCode = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool PostalCodeIsChanged => CachedItem.PostalCode != CurrentItem.PostalCode;

        public string PostalCodeOriginalValue => CachedItem.PostalCode;

        public string PostalPlace
        {
            get => CurrentItem.PostalPlace;
            set
            {
                CurrentItem.PostalPlace = value;
                RaiseOnPropertyChanged();
            }
        }
        public bool PostalPlaceIsChanged => CachedItem.PostalPlace != CurrentItem.PostalPlace;

        public string PostalPlaceOriginalValue => CachedItem.PostalPlace;

        public override bool IsChanged =>
            FullNameIsChanged || StreetIsChanged || NumberIsChanged || PostalCodeIsChanged ||
            PostalPlaceIsChanged;

        public int Id
        {
            get => CurrentItem.Id;
            set
            {
                CurrentItem.Id = value;
                RaiseOnPropertyChanged();
            }
        }


        public override void ChildPropertyChanged()
        {
            DisplayName = FullName;
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(Street));
            OnPropertyChanged(nameof(Number));
            OnPropertyChanged(nameof(PostalCode));
            OnPropertyChanged(nameof(PostalPlace));
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(IsChanged));
            OnPropertyChanged(nameof(NumberIsChanged));
            OnPropertyChanged(nameof(PostalCodeIsChanged));
            OnPropertyChanged(nameof(PostalPlaceIsChanged));
            OnPropertyChanged(nameof(StreetIsChanged));
            OnPropertyChanged(nameof(FullNameIsChanged));
            OnPropertyChanged(nameof(DisplayName));
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
            base.Save();
        }

        public AddressViewModel(IEventAggregator eventAggregator, Domain.Address address)
        {
            _eventAggregator = eventAggregator;
            _service = new AddressService(Context);
            DisplayName = address == null ? "Nowy adres" : address.FullName;
            address ??= new Domain.Address();
            CachedItem = (new Domain.Address()).CopyProperties(address);
            CurrentItem = address;
        }
    }
}
