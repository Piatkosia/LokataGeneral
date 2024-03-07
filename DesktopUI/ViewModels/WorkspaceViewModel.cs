using System;
using System.Windows.Input;

using DesktopUI;

using Lokata.DataAccess;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.Views.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Lokata.DesktopUI.ViewModels
{
    public class WorkspaceViewModel : BaseViewModel
    {
        protected readonly IMessageDialogService _messageDialogService;
        public string DisplayName
        {
            get
            {
                if (HasErrors)
                    return $"! {_displayName}";
                else if (IsChanged)
                    return $"* {_displayName}";
                else return _displayName;

            }
            set
            {
                _displayName = value;
                OnPropertyChanged();
            }
        }

        public virtual bool IsChanged { get; set; }

        private BaseCommand _closeCommand;
        public event EventHandler RequestClose;

        public DatabaseContext Context = new();
        private string _displayName;

        public WorkspaceViewModel()
        {
            if (App.ServiceProvider != null)
                _messageDialogService = App.ServiceProvider.GetRequiredService<IMessageDialogService>();
        }

        public ICommand CloseCommand
        {
            get
            {
                _closeCommand ??= new BaseCommand(OnRequestClose);
                return _closeCommand;
            }
        }
        public void OnRequestClose()
        {
            if (IsChanged)
            {
                var result = _messageDialogService.ShowYesNoDialog("Zamknąć kartę?",
                    "Utracisz wszystkie niezapisane zmiany. Na pewno chcesz zamknąć kartę??",
                    MessageDialogResult.Nie);
                if (result == MessageDialogResult.Nie)
                {
                    return;
                }
            }
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
