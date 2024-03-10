using System;
using System.Collections.ObjectModel;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Competitions;
using Lokata.Domain;
using Lokata.Domain.Services;
using Lokata.Utils;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Competitions
{
    public class CompetitionsViewModel : SingleViewModel<Domain.Competitions>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ICompetitionsService _service;
        private readonly IPlaceService _placeService;
        private ObservableCollection<LookupItem> _places;

        public int Id
        {
            get => CurrentItem.Id;
            set
            {
                CurrentItem.Id = value;
                RaiseOnPropertyChanged();
            }
        }

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

        public string Description
        {
            get => CurrentItem.Description;
            set
            {
                CurrentItem.Description = value;
                RaiseOnPropertyChanged();
            }
        }
        public bool DescriptionIsChanged => CachedItem.Description != CurrentItem.Description;
        public string DescriptionOriginalValue => CachedItem.Description;

        public int? PlaceId
        {
            get => CurrentItem.PlaceId;
            set
            {
                CurrentItem.PlaceId = value;
                RaiseOnPropertyChanged();
            }
        }
        public bool PlaceIdIsChanged => CachedItem.PlaceId != CurrentItem.PlaceId;
        public int? PlaceIdOriginalValue => CachedItem.PlaceId;

        public DateTime? Date
        {
            get => CurrentItem.Date;
            set
            {
                CurrentItem.Date = value;
                RaiseOnPropertyChanged();
            }
        }
        public bool DateIsChanged => CachedItem.Date != CurrentItem.Date;
        public DateTime? DateOriginalValue => CachedItem.Date;

        public ObservableCollection<LookupItem> Places
        {
            get => _places;
            set
            {
                _places = value;
                OnPropertyChanged();
            }
        }

        public override bool IsChanged => NameIsChanged || DescriptionIsChanged || PlaceIdIsChanged || DateIsChanged;

        public CompetitionsViewModel(IEventAggregator eventAggregator, Domain.Competitions competitions)
        {
            _eventAggregator = eventAggregator;
            _service = new CompetitionsService(Context);
            _placeService = new PlaceService(Context);
            Places = new ObservableCollection<LookupItem>(_placeService.GetLookup());
            DisplayName = competitions == null ? "Nowe zawody" : competitions.Name;
            competitions ??= new Domain.Competitions();
            CachedItem = (new Domain.Competitions()).CopyProperties(competitions);
            CurrentItem = competitions;
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
            _eventAggregator.GetEvent<CompetitionsSaved>().Publish(CurrentItem);
            base.Save();
        }

        public override void ChildPropertyChanged()
        {
            DisplayName = Name;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(PlaceId));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(IsChanged));
            OnPropertyChanged(nameof(NameIsChanged));
            OnPropertyChanged(nameof(DescriptionIsChanged));
            OnPropertyChanged(nameof(PlaceIdIsChanged));
            OnPropertyChanged(nameof(DateIsChanged));
        }
    }
}
