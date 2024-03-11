using System.Collections.ObjectModel;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Approach;
using Lokata.Domain;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Approach
{
    public class ApproachViewModel : SingleViewModel<Domain.Approach>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IApproachService _service;
        private readonly ICompetitionService _competitionService;
        private readonly ICompetitionsService _competitionsService;
        private readonly IInstructorService _instructorService;
        private readonly IUmpireService _umpireService;
        private ObservableCollection<LookupItem> _competitionList;
        private ObservableCollection<LookupItem> _competitionsList;
        private ObservableCollection<LookupItem> _instructorList;
        private ObservableCollection<LookupItem> _umpireList;

        private ObservableCollection<LookupItem> CompetitionList
        {
            get => _competitionList;
            set
            {
                _competitionList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LookupItem> CompetitionsList
        {
            get => _competitionsList;
            set
            {
                _competitionsList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LookupItem> InstructorList
        {
            get => _instructorList;
            set
            {
                _instructorList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LookupItem> UmpireList
        {
            get => _umpireList;
            set
            {
                _umpireList = value;
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

        public int? CompetitionId
        {
            get => CurrentItem.CompetitionId;
            set
            {
                CurrentItem.CompetitionId = value;
                RaiseOnPropertyChanged();
            }
        }

        public int? CompetitionIdOriginalValue => CachedItem.CompetitionId;

        public bool CompetitionIdIsChanged => CachedItem.CompetitionId != CurrentItem.CompetitionId;

        public int? CompetitionsId
        {
            get => CurrentItem.CompetitionsId;
            set
            {
                CurrentItem.CompetitionsId = value;
                RaiseOnPropertyChanged();
            }
        }
        public int? CompetitionsIdOriginalValue => CachedItem.CompetitionsId;
        public bool CompetitionsIdIsChanged => CachedItem.CompetitionsId != CurrentItem.CompetitionsId;

        public int? InstructorId
        {
            get => CurrentItem.InstructorId;
            set
            {
                CurrentItem.InstructorId = value;
                RaiseOnPropertyChanged();
            }
        }

        public int? InstructorIdOriginalValue => CachedItem.InstructorId;
        public bool InstructorIdIsChanged => CachedItem.InstructorId != CurrentItem.InstructorId;

        public int? UmpireId
        {
            get => CurrentItem.UmpireId;
            set
            {
                CurrentItem.UmpireId = value;
                RaiseOnPropertyChanged();
            }
        }

        public int? UmpireIdOriginalValue => CachedItem.UmpireId;

        public bool UmpireIdIsChanged => CachedItem.UmpireId != CurrentItem.UmpireId;

        public override bool IsChanged =>
            CompetitionIdIsChanged || CompetitionsIdIsChanged || InstructorIdIsChanged || UmpireIdIsChanged;

        public override void ChildPropertyChanged()
        {
            RaiseOnPropertyChanged(nameof(IsChanged));
            RaiseOnPropertyChanged(nameof(CompetitionIdIsChanged));
            RaiseOnPropertyChanged(nameof(CompetitionsIdIsChanged));
            RaiseOnPropertyChanged(nameof(InstructorIdIsChanged));
            RaiseOnPropertyChanged(nameof(UmpireIdIsChanged));
            RaiseOnPropertyChanged(nameof(CompetitionId));
            RaiseOnPropertyChanged(nameof(CompetitionsId));
            RaiseOnPropertyChanged(nameof(InstructorId));
            RaiseOnPropertyChanged(nameof(UmpireId));
        }

        public ApproachViewModel(IEventAggregator eventAggregator, Domain.Approach approach, ObservableCollection<LookupItem> competitionsList, ObservableCollection<LookupItem> instructorList, ObservableCollection<LookupItem> umpireList)
        {
            DisplayName = "Podejście";
            _eventAggregator = eventAggregator;
            CompetitionsList = competitionsList;
            InstructorList = instructorList;
            UmpireList = umpireList;
            _service = new ApproachService(Context);
            _competitionService = new CompetitionService(Context);
            _competitionsService = new CompetitionsService(Context);
            _instructorService = new InstructorService(Context);
            _umpireService = new UmpireService(Context);
            approach ??= new Domain.Approach();
            CompetitionList = new ObservableCollection<LookupItem>(_competitionService.GetLookup());
            CompetitionsList = new ObservableCollection<LookupItem>(_competitionsService.GetLookup());
            InstructorList = new ObservableCollection<LookupItem>(_instructorService.GetLookup());
            UmpireList = new ObservableCollection<LookupItem>(_umpireService.GetLookup());
            CurrentItem = approach;

        }

        protected override void Save()
        {
            var competitionBackup = CurrentItem.Competition;
            var competitionsBackup = CurrentItem.Competitions;
            var instructorBackup = CurrentItem.Instructor;
            var umpireBackup = CurrentItem.Umpire;
            //to prevent copy instead of linking
            CurrentItem.Competition = null;
            CurrentItem.Competitions = null;
            CurrentItem.Instructor = null;
            CurrentItem.Umpire = null;
            if (CurrentItem.Id == 0)
            {
                _service.Create(CurrentItem);
            }
            else
            {
                _service.Update(CurrentItem);
            }
            _eventAggregator.GetEvent<ApproachSaved>().Publish(CurrentItem);
            base.Save();
            CurrentItem.Competition = competitionBackup;
            CurrentItem.Competitions = competitionsBackup;
            CurrentItem.Instructor = instructorBackup;
            CurrentItem.Umpire = umpireBackup;
        }
    }
}
