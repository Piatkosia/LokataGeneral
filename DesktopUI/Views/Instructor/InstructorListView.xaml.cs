using DesktopUI;

using Lokata.DesktopUI.Events.Instructor;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.UserControls;

using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace Lokata.DesktopUI.Views.Instructor
{
    /// <summary>
    /// Interaction logic for InstructorListView.xaml
    /// </summary>
    public partial class InstructorListView : AllViewBase
    {
        private IEventAggregator _eventAggregator;
        public InstructorListView()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                _eventAggregator = App.ServiceProvider.GetRequiredService<IEventAggregator>();
                _eventAggregator.GetEvent<InstructorListAsExcelSaved>().Subscribe(SaveAsExcel);
                _eventAggregator.GetEvent<InstructorListAsPdfSaved>().Subscribe(SaveAsPdf);
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
