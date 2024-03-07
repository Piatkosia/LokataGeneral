using System.IO;

using Microsoft.Win32;

using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter;

using Syncfusion.XlsIO;

namespace Lokata.DesktopUI.Helpers
{
    public static class ExportHelper
    {
        public static void SaveAsExcel(SfDataGrid dataGrid)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files(*.xlsx)|*.xlsx"
            };
            if (saveFileDialog.ShowDialog() != true) return;

            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2013;
            var excelEngine = dataGrid.ExportToExcel(dataGrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            workBook.SaveAs(saveFileDialog.FileName);
        }

        public static void SaveAsPdf(SfDataGrid dataGrid)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files(*.pdf)|*.pdf"
            };

            if (saveFileDialog.ShowDialog() != true) return;
            var document = dataGrid.ExportToPdf();
            using (Stream stream = saveFileDialog.OpenFile())
            {
                document.Save(stream);
            }
        }
    }
}
