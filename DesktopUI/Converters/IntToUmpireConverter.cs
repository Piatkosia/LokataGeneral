using System;
using System.Globalization;
using System.Windows.Data;

using Lokata.DataAccess;

namespace Lokata.DesktopUI.Converters
{
    public class IntToUmpireConverter : IValueConverter
    {
        public DatabaseContext Context = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int?)value;
            if (id.HasValue)
            {
                var umpire = Context.Umpires.Find(id);
                if (umpire != null)
                {
                    return umpire.FullName;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
