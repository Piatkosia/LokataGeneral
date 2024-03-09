using System;
using System.Globalization;
using System.Windows.Data;

using Lokata.DataAccess;

namespace Lokata.DesktopUI.Converters
{
    public class IntToAddressConverter : IValueConverter
    {
        public DatabaseContext Context = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int?)value;
            if (id.HasValue)
            {
                var address = Context.Addresses.Find(id);
                if (address != null)
                {
                    return $"{address.FullName} {address.Street} {address.Number} ; {address.PostalCode} {address.PostalPlace}";
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
