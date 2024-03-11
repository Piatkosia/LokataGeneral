using System;
using System.Globalization;
using System.Windows.Data;

using Lokata.DataAccess;

namespace Lokata.DesktopUI.Converters
{
    public class IntToCompetitionsConverter : IValueConverter
    {
        public DatabaseContext Context = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int?)value;
            if (id.HasValue)
            {
                var competitions = Context.CompetitionsList.Find(id);
                if (competitions != null)
                {
                    return competitions.Name;
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
