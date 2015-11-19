using System;
using System.Globalization;
using System.Windows.Data;

namespace mba_application.MBAComponents.MBAConverters
{
    class CurrentCaptionToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int) value == 0 ? "DeepPink" : "Aquamarine";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
