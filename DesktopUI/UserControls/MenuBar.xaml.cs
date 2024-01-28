using System;
using System.Windows;
using System.Windows.Controls;

namespace Lokata.DesktopUI.UserControls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public event EventHandler AddressClicked;
        public MenuBar()
        {
            InitializeComponent();
        }

        private void AddressClickedHandler(object sender, RoutedEventArgs e)
        {
            AddressClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
