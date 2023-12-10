using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lokata.DesktopUI.Helpers
{
    public class PrintCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Visual param = (Visual)parameter;
            PrintDialog printDlg = new PrintDialog();
            printDlg.ShowDialog();
            printDlg.PrintVisual(param, "Window Printing.");
        }

        public event EventHandler CanExecuteChanged;
    }
}
