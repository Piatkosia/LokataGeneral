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
        public T CurrentItem { get; set; }
        public T CachedItem { get; set; }
        public ICommand SaveAndCloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public SingleViewModel()
        {
            SaveAndCloseCommand = new BaseCommand(OnSaveAndClose);
            SaveCommand = new BaseCommand(Save);
            _messageDialogService = App.ServiceProvider.GetRequiredService<IMessageDialogService>();
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
                var result = _messageDialogService.ShowYesNoDialog("Close application?",
                    "You'll lose your changes if you close this application. Close it?",
                    MessageDialogResult.No);
            }
        }

        protected virtual void Save()
        {

        }
    }
}
