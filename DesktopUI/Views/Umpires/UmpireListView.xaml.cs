using DesktopUI;

using Lokata.DesktopUI.Events.Umpire;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.UserControls;

using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace Lokata.DesktopUI.Views.Umpires
{
    /// <summary>
    /// Interaction logic for UmpireListView.xaml
    /// </summary>
    public partial class UmpireListView : AllViewBase
    {
        private IEventAggregator _eventAggregator;
        public UmpireListView()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                _eventAggregator = App.ServiceProvider.GetRequiredService<IEventAggregator>();
                _eventAggregator.GetEvent<UmpireListAsExcelSaved>().Subscribe(SaveAsExcel);
                _eventAggregator.GetEvent<UmpireListAsPdfSaved>().Subscribe(SaveAsPdf);
            }
        }

        private void SaveAsPdf()
        {
            ExportHelper.SaveAsPdf(DataGrid);
        }

        private void SaveAsExcel()
        {
            ExportHelper.SaveAsExcel(DataGrid);
        }
    }
}
