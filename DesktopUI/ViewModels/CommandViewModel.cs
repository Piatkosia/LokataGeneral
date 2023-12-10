using System.Windows.Input;

namespace Lokata.DesktopUI.ViewModels
{
    internal class CommandViewModel
    {
        public string DisplayName { get; set; }
        public ICommand Command { get; set; }
        public CommandViewModel(string displayName, ICommand command)
        {
            DisplayName = displayName;
            Command = command;
        }
    }
}
