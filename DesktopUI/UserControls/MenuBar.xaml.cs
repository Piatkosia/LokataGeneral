using System.Windows.Controls;

using DesktopUI;

using Lokata.DesktopUI.UserControlsModels;

using Microsoft.Extensions.DependencyInjection;

namespace Lokata.DesktopUI.UserControls
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
            //W sumie if nie wejdzie tylko w przypadku edytora, a ja lubię mieć podgląd skoro jest dostępny.
            if (App.ServiceProvider != null)
                DataContext = App.ServiceProvider.GetRequiredService<MenuBarModel>();
        }
    }
}
