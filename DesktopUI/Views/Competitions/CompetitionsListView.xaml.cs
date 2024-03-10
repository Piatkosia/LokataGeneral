using DesktopUI;

using Lokata.DesktopUI.Events.Competitions;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.UserControls;

using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace Lokata.DesktopUI.Views.Competitions
{
    /// <summary>
    /// Interaction logic for CompetitionsListView.xaml
    /// </summary>
    public partial class CompetitionsListView : AllViewBase
    {
        private IEventAggregator _eventAggregator;
        public CompetitionsListView()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                _eventAggregator = App.ServiceProvider.GetRequiredService<IEventAggregator>();
                _eventAggregator.GetEvent<CompetitionsListAsExcelSaved>().Subscribe(SaveAsExcel);
                _eventAggregator.GetEvent<CompetitionsListAsPdfSaved>().Subscribe(SaveAsPdf);
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
