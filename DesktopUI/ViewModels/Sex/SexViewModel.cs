using Lokata.DataService;
using Lokata.DesktopUI.Events.Sex;
using Lokata.Domain.Services;
using Lokata.Utils;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Sex
{
    public class SexViewModel : SingleViewModel<Domain.Sex>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ISexService _service;

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

        public bool AsMale
        {
            get => CurrentItem.AsMale;
            set
            {
                CurrentItem.AsMale = value;
                RaiseOnPropertyChanged();
            }
        }
        public bool AsMaleIsChanged => CachedItem.AsMale != CurrentItem.AsMale;
        public bool AsMaleOriginalValue => CachedItem.AsMale;

        public bool AsFemale
        {
            get => CurrentItem.AsFemale;
            set
            {
                CurrentItem.AsFemale = value;
                RaiseOnPropertyChanged();
            }
        }
        public bool AsFemaleIsChanged => CachedItem.AsFemale != CurrentItem.AsFemale;
        public bool AsFemaleOriginalValue => CachedItem.AsFemale;

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
            DisplayName = Name;
            OnPropertyChanged(nameof(NameIsChanged));
            OnPropertyChanged(nameof(AsMaleIsChanged));
            OnPropertyChanged(nameof(AsFemaleIsChanged));
            OnPropertyChanged(nameof(IsValid));
            OnPropertyChanged(nameof(IsChanged));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(AsMale));
            OnPropertyChanged(nameof(AsFemale));
        }

        private bool IsChanged => NameIsChanged || AsMaleIsChanged || AsFemaleIsChanged;

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
            OnPropertyChanged(nameof(IsChanged));
            _eventAggregator.GetEvent<SexSaved>().Publish(CurrentItem);
        }
        public SexViewModel(IEventAggregator eventAggregator, Domain.Sex sex)
        {
            _eventAggregator = eventAggregator;
            _service = new SexService(Context);
            DisplayName = sex == null ? "Nowa płeć" : sex.Name;
            sex ??= new Domain.Sex();
            CachedItem = new Domain.Sex().CopyProperties(sex);
            CurrentItem = sex;
        }
    }
}
