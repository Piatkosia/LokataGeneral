using System;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Instructor;
using Lokata.Domain.Services;
using Lokata.Utils;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Instructor
{
    public class InstructorViewModel : SingleViewModel<Domain.Instructor>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IInstructorService _service;

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

        public DateTime? DocumentValidUntil
        {
            get => CurrentItem.DocumentValidUntil;
            set
            {
                CurrentItem.DocumentValidUntil = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool DocumentValidUntilIsChanged => CachedItem.DocumentValidUntil != CurrentItem.DocumentValidUntil;

        public DateTime? DocumentValidUntilOriginalValue => CachedItem.DocumentValidUntil;

        public override bool IsChanged => FullNameIsChanged || DocumentValidUntilIsChanged;
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
            OnPropertyChanged(nameof(DocumentValidUntil));
            OnPropertyChanged(nameof(DisplayName));
            OnPropertyChanged(nameof(IsChanged));
            OnPropertyChanged(nameof(FullNameIsChanged));
            OnPropertyChanged(nameof(DocumentValidUntilIsChanged));
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
            _eventAggregator.GetEvent<InstructorSaved>().Publish(CurrentItem);
            base.Save();
        }

        public InstructorViewModel(IEventAggregator eventAggregator, Domain.Instructor instructor)
        {
            _eventAggregator = eventAggregator;
            _service = new InstructorService(Context);
            DisplayName = instructor == null ? "Nowy instruktor" : instructor.FullName;
            instructor ??= new Domain.Instructor();
            CachedItem = (new Domain.Instructor()).CopyProperties(instructor);
            CurrentItem = instructor;
        }
    }
}
