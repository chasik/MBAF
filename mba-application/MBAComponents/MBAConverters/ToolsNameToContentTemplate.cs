using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace mba_application.MBAComponents.MBAConverters
{
    public class ToolsNameToContentTemplate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "tools-phone":
                    return Application.Current.FindResource("PhoneMain") as DataTemplate;
                case "tools-phone-history":
                    return Application.Current.FindResource("PhoneHistory") as DataTemplate;
                case "tools-calc":
                    return Application.Current.FindResource("CalcTool") as DataTemplate;
                case "tools-chat":
                    return Application.Current.FindResource("ChatTool") as DataTemplate;
                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
