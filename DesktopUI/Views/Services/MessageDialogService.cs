using System.Windows;

namespace Lokata.DesktopUI.Views.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowYesNoDialog(string title, string text,
            MessageDialogResult defaultResult = MessageDialogResult.Tak)
        {
            var dlg = new MessageDialog(title, text, defaultResult, MessageDialogResult.Tak, MessageDialogResult.Nie);
            dlg.Owner = Application.Current.MainWindow;
            return dlg.ShowDialog();
        }
    }
}
