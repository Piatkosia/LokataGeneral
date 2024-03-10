using System;
using System.Globalization;
using System.Windows.Data;

using Lokata.DataAccess;

namespace Lokata.DesktopUI.Converters
{
    public class IntToPlaceConverter : IValueConverter
    {
        public DatabaseContext Context = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int?)value;
            if (id.HasValue)
            {
                var place = Context.Places.Find(id);
                if (place != null)
                {
                    return place.Name;
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
