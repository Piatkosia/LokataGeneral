using Lokata.DataService;
using Lokata.DesktopUI.Events.Competition;
using Lokata.Domain.Services;
using Lokata.Mobile.Legacy.Helpers;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Competition
{
    public class CompetitionViewModel : SingleViewModel<Domain.Competition>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ICompetitionService _service;

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

        public int? SeriesCount
        {
            get => CurrentItem.SeriesCount;
            set
            {
                CurrentItem.SeriesCount = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool SeriesCountIsChanged => CachedItem.SeriesCount != CurrentItem.SeriesCount;

        public int? SeriesCountOriginalValue => CachedItem.SeriesCount;


        public int? MaxPointsPerSeries
        {
            get => CurrentItem.MaxPointsPerSeries;
            set
            {
                CurrentItem.MaxPointsPerSeries = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool MaxPointsPerSeriesIsChanged => CachedItem.MaxPointsPerSeries != CurrentItem.MaxPointsPerSeries;

        public int? MaxPointsPerSeriesOriginalValue => CachedItem.MaxPointsPerSeries;

        public override bool IsChanged => NameIsChanged || SeriesCountIsChanged || MaxPointsPerSeriesIsChanged;

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
            _eventAggregator.GetEvent<CompetitionSaved>().Publish(CurrentItem);
            base.Save();
        }

        public override void ChildPropertyChanged()
        {
            DisplayName = Name;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(SeriesCount));
            OnPropertyChanged(nameof(MaxPointsPerSeries));
            OnPropertyChanged(nameof(DisplayName));
            OnPropertyChanged(nameof(NameIsChanged));
            OnPropertyChanged(nameof(SeriesCountIsChanged));
            OnPropertyChanged(nameof(MaxPointsPerSeriesIsChanged));
            OnPropertyChanged(nameof(IsChanged));
        }

        public CompetitionViewModel(IEventAggregator eventAggregator, Domain.Competition competition)
        {
            _eventAggregator = eventAggregator;
            _service = new CompetitionService(Context);
            DisplayName = competition == null ? "Nowa konkurencja" : competition.Name;
            competition ??= new Domain.Competition();
            CachedItem = (new Domain.Competition()).CopyProperties(competition);
            CurrentItem = competition;
        }
    }
}
