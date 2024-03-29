﻿using DesktopUI;

using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Helpers;
using Lokata.DesktopUI.UserControls;

using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace Lokata.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for AddressListView.xaml
    /// </summary>
    public partial class AddressListView : AllViewBase
    {
        private IEventAggregator _eventAggregator;

        public AddressListView()
        {
            InitializeComponent();
            if (App.ServiceProvider != null)
            {
                _eventAggregator = App.ServiceProvider.GetRequiredService<IEventAggregator>();
                _eventAggregator.GetEvent<AddressListAsExcelSaved>().Subscribe(SaveAsExcel);
                _eventAggregator.GetEvent<AddressListAsPdfSaved>().Subscribe(SaveAsPdf);
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
