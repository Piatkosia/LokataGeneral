using System;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Umpire;
using Lokata.Domain.Services;
using Lokata.Mobile.Legacy.Helpers;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Umpire
{
    public class UmpireViewModel : SingleViewModel<Domain.Umpire>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IUmpireService _service;

        public UmpireViewModel(IEventAggregator eventAggregator, Domain.Umpire umpire)
        {
            _eventAggregator = eventAggregator;
            _service = new UmpireService(Context);
            if (umpire == null)
            {
                DisplayName = "Nowy sędzia";
            }
            else
            {
                DisplayName = umpire.FullName;
            }
            CachedItem = (new Domain.Umpire()).CopyProperties(umpire);
            CurrentItem = umpire;
        }

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

        public string PermissionDocumentNumber
        {
            get => CurrentItem.PermissionDocumentNumber;
            set
            {
                CurrentItem.PermissionDocumentNumber = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool PermissionDocumentNumberIsChanged => CachedItem.PermissionDocumentNumber != CurrentItem.PermissionDocumentNumber;

        public string PermissionDocumentNumberOriginalValue => CachedItem.PermissionDocumentNumber;

        public DateTime? PermissionDocumentDate
        {
            get => CurrentItem.PermissionDocumentDate;
            set
            {
                CurrentItem.PermissionDocumentDate = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool PermissionDocumentDateIsChanged => CachedItem.PermissionDocumentDate != CurrentItem.PermissionDocumentDate;
        public DateTime? PermissionDocumentDateOriginalValue => CachedItem.PermissionDocumentDate;

        public DateTime? PermissionValidUntil
        {
            get => CurrentItem.PermissionValidUntil;
            set
            {
                CurrentItem.PermissionValidUntil = value;
                RaiseOnPropertyChanged();
            }
        }

        public bool PermissionValidUntilIsChanged => CachedItem.PermissionValidUntil != CurrentItem.PermissionValidUntil;
        public DateTime? PermissionValidUntilOriginalValue => CachedItem.PermissionValidUntil;

        public override bool IsChanged => FullNameIsChanged || PermissionDocumentNumberIsChanged || PermissionDocumentDateIsChanged || PermissionValidUntilIsChanged;

        public override void ChildPropertyChanged()
        {
            DisplayName = FullName;
            OnPropertyChanged(nameof(FullName));
            OnPropertyChanged(nameof(PermissionDocumentNumber));
            OnPropertyChanged(nameof(PermissionDocumentDate));
            OnPropertyChanged(nameof(PermissionValidUntil));
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
            _eventAggregator.GetEvent<UmpireSaved>().Publish(CurrentItem);
            base.Save();
        }
    }
}
