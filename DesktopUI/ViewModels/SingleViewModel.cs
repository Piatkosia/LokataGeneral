using System.Windows.Input;

using DesktopUI;

using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.Views.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Lokata.DesktopUI.ViewModels
{
    public class SingleViewModel<T> : WorkspaceViewModel
    {
        private readonly IMessageDialogService _messageDialogService;
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
            SaveAndCloseCommand = new BaseCommand(OnSaveAndClose);
            SaveCommand = new BaseCommand(Save);
            ResetCommand = new BaseCommand(Reset);
            _messageDialogService = App.ServiceProvider.GetRequiredService<IMessageDialogService>();
        }

        public void Reset()
        {
            CurrentItem = CachedItem;
            ChildPropertyChanged();
        }

        public virtual void ChildPropertyChanged()
        {

        }

        public virtual bool IsValid()
        {
            return true;
        }

        private void OnSaveAndClose()
        {
            if (IsValid())
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

        }
    }
}
