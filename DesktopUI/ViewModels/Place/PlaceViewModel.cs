using System.Collections.ObjectModel;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Events.Place;
using Lokata.Domain;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Place
{
    public class PlaceViewModel : SingleViewModel<Domain.Place>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IPlaceService _service;

        private readonly IAddressService _addressService;
        private ObservableCollection<LookupItem> _addresses;

        public string Name
        {
            get => CurrentItem.Name;
            set
            {
                CurrentItem.Name = value;
                RaiseOnPropertyChanged();
                DisplayName = value;
            }
        }

        public bool NameIsChanged => CachedItem.Name != CurrentItem.Name;

        public string NameOriginalValue => CachedItem.Name;

        public int? Address
        {
            get => CurrentItem.Address;
            set
            {
                CurrentItem.Address = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool AddressIsChanged => CachedItem.Address != CurrentItem.Address;

        public int? AddressOriginalValue => CachedItem.Address;

        public int? ShootingPlacesCount
        {
            get => CurrentItem.ShootingPlacesCount;
            set
            {
                CurrentItem.ShootingPlacesCount = value;
                RaiseOnPropertyChanged();
            }
        }

        public int Id
        {
            get => CurrentItem.Id;
            set
            {
                CurrentItem.Id = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool ShootingPlacesCountIsChanged => CachedItem.ShootingPlacesCount != CurrentItem.ShootingPlacesCount;

        public int? ShootingPlacesCountOriginalValue => CachedItem.ShootingPlacesCount;

        public override bool IsChanged => NameIsChanged || AddressIsChanged || ShootingPlacesCountIsChanged;

        public ObservableCollection<LookupItem> Addresses
        {
            get => _addresses;
            set
            {
                _addresses = value;
                OnPropertyChanged();
            }
        }

        public override void ChildPropertyChanged()
        {
            DisplayName = Name;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Address));
            OnPropertyChanged(nameof(ShootingPlacesCount));
            OnPropertyChanged(nameof(IsChanged));
            OnPropertyChanged(nameof(AddressIsChanged));
            OnPropertyChanged(nameof(NameIsChanged));
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
            _eventAggregator.GetEvent<PlaceSaved>().Publish(CurrentItem);
            base.Save();
        }

        public PlaceViewModel(IEventAggregator eventAggregator, Domain.Place place)
        {
            _eventAggregator = eventAggregator;
            _service = new PlaceService(Context);
            _addressService = new AddressService(Context);
            _eventAggregator.GetEvent<AddressSaved>().Subscribe(OnAddressSaved);
            DisplayName = place == null ? "Nowe miejsce" : place.Name;
            Addresses = new ObservableCollection<LookupItem>(_addressService.GetLookup());
        }

        private void OnAddressSaved(Domain.Address obj)
        {
            //jak ktoś zmieni, to się przeładuje lista
            Addresses = new ObservableCollection<LookupItem>(_addressService.GetLookup());
        }

    }
}
