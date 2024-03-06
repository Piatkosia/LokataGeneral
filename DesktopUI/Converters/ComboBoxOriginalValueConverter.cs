using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

using Lokata.Domain;

namespace Lokata.DesktopUI.Converters
{
    public class ComboBoxOriginalValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int)value;
            var comboBox = parameter as ComboBox;
            if (comboBox != null && comboBox.ItemsSource != null)
            {
                var lookupItem
                    = comboBox.ItemsSource.OfType<LookupItem>().SingleOrDefault(l => l.Id == id);
                if (lookupItem != null)
                {
                    return lookupItem.DisplayValue;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //na razie używam tylko do wyświetlania, więc mogę olać.
            throw new NotImplementedException();
        }
    }
}
