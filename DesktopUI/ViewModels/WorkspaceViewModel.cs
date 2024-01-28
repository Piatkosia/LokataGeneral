using Lokata.DataAccess;
using Lokata.DesktopUI.Helpers;
using System;
using System.Windows.Input;

namespace Lokata.DesktopUI.ViewModels
{
    public class WorkspaceViewModel : BaseViewModel
    {
        public string DisplayName { get; set; }
        private BaseCommand _closeCommand;
        public event EventHandler RequestClose;

        public DatabaseContext Context = new DatabaseContext();
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
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
