using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.Views.Services;

namespace Lokata.DesktopUI.ViewModels
{
    public class SingleViewModel<T> : WorkspaceViewModel
    {

        private T _currentItem;

        public T CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }

        public T CachedItem { get; set; }
        public ICommand SaveAndCloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        public SingleViewModel()
        {
            SaveAndCloseCommand = new BaseCommand(OnSaveAndClose, CanSave);
            SaveCommand = new BaseCommand(Save, CanSave);
            ResetCommand = new BaseCommand(Reset);
        }

        private bool CanSave()
        {
            return IsChanged && IsValid;
        }

        public void Reset()
        {
            CurrentItem = CachedItem;
            ChildPropertyChanged();
        }

        public virtual void ChildPropertyChanged()
        {

        }

        public virtual bool IsValid => !HasErrors;

        private void OnSaveAndClose()
        {
            if (!IsChanged)
            {
                OnRequestClose();
            }
            if (IsValid)
            {
                Save();

                OnRequestClose();

            }
            else
            {
                var result = _messageDialogService.ShowYesNoDialog("Czy zamknąć?",
                    "Formularz zawiera błędy i nie zostanie zapisany. Chcesz go zamknąć mimo to?",
                    MessageDialogResult.Nie);
                if (result == MessageDialogResult.Tak)
                {
                    OnRequestClose();
                }
            }
        }

        protected virtual void Save()
        {
            CachedItem = CurrentItem;
        }

        private void Validate()
        {
            ClearErrors();

            var results = new List<ValidationResult>();
            var context = new ValidationContext(CurrentItem);
            Validator.TryValidateObject(CurrentItem, context, results, true);

            if (results.Any())
            {
                var propertyNames = results.SelectMany(r => r.MemberNames).Distinct().ToList();

                foreach (var propertyName in propertyNames)
                {
                    Errors[propertyName] = results
                        .Where(r => r.MemberNames.Contains(propertyName))
                        .Select(r => r.ErrorMessage)
                        .Distinct()
                        .ToList();
                    OnErrorsChanged(propertyName);
                }
            }
            OnPropertyChanged(nameof(IsValid));
            ((BaseCommand)SaveAndCloseCommand).RaiseCanExecuteChanged();
            ((BaseCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }

        public virtual void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged(propertyName + "IsChanged");
            OnPropertyChanged("IsChanged");
            OnPropertyChanged("DisplayName");
            Validate();
        }

    }
}
