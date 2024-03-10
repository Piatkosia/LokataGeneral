using DesktopUI;

using Lokata.DesktopUI.Events.Sex;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.UserControls;

using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace Lokata.DesktopUI.Views.Sex
{
    /// <summary>
    /// Interaction logic for SexListView.xaml
    /// </summary>
    public partial class SexListView : AllViewBase
    {
        private IEventAggregator _eventAggregator;
        public SexListView()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                _eventAggregator = App.ServiceProvider.GetRequiredService<IEventAggregator>();
                _eventAggregator.GetEvent<SexListAsExcelSaved>().Subscribe(SaveAsExcel);
                _eventAggregator.GetEvent<SexListAsPdfSaved>().Subscribe(SaveAsPdf);
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
