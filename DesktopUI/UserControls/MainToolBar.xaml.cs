using System.Windows.Controls;

using DesktopUI;

using Lokata.DesktopUI.UserControlsModels;

using Microsoft.Extensions.DependencyInjection;

namespace Lokata.DesktopUI.UserControls
{
    /// <summary>
    /// Interaction logic for MainToolBar.xaml
    /// </summary>
    public partial class MainToolBar : UserControl
    {
        public MainToolBar()
        {
            InitializeComponent();
            DataContext = App.ServiceProvider.GetRequiredService<MenuBarModel>();
        }
    }
}
