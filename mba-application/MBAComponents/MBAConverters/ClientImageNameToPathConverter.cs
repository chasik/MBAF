using System;
using System.Globalization;
using System.Windows.Data;

namespace mba_application.MBAComponents.MBAConverters
{
    class ClientImageNameToPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "\\Images\\" + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
