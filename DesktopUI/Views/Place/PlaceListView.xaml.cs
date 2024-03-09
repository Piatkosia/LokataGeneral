using DesktopUI;

using Lokata.DesktopUI.Events.Place;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.UserControls;

using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace Lokata.DesktopUI.Views.Place
{
    /// <summary>
    /// Interaction logic for PlaceListView.xaml
    /// </summary>
    public partial class PlaceListView : AllViewBase
    {
        private IEventAggregator _eventAggregator;
        public PlaceListView()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                _eventAggregator = App.ServiceProvider.GetRequiredService<IEventAggregator>();
                _eventAggregator.GetEvent<PlaceListAsExcelSaved>().Subscribe(SaveAsExcel);
                _eventAggregator.GetEvent<PlaceListAsPdfSaved>().Subscribe(SaveAsPdf);
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
