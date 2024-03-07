using DesktopUI;

using Lokata.DesktopUI.Events.Competition;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.UserControls;

using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace Lokata.DesktopUI.Views.Competition
{
    /// <summary>
    /// Interaction logic for CompetitionListView.xaml
    /// </summary>
    public partial class CompetitionListView : AllViewBase
    {
        private IEventAggregator _eventAggregator;
        public CompetitionListView()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                _eventAggregator = App.ServiceProvider.GetRequiredService<IEventAggregator>();
                _eventAggregator.GetEvent<CompetitionListAsExcelSaved>().Subscribe(SaveAsExcel);
                _eventAggregator.GetEvent<CompetitionListAsPdfSaved>().Subscribe(SaveAsPdf);
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
