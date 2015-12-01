using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace mba_application.MBAComponents.MBAConverters
{
    class PhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value == null ? string.Empty : value.ToString();
            switch (val.Length)
            {
                case 1: return val;
                case 2: return val[0] + " (" + val[1];
                case 3: return val[0] + " (" + val[1] + val[2];
                case 4: return val[0] + " (" + val[1] + val[2] + val[3];
                case 5: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4];
                case 6: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4] + val[5];
                case 7: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4] + val[5] + val[6];
                case 8: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4] + val[5] + val[6] + "-" + val[7];
                case 9: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4] + val[5] + val[6] + "-" + val[7] + val[8];
                case 10: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4] + val[5] + val[6] + "-" + val[7] + val[8] + "-" + val[9];
                case 11: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4] + val[5] + val[6] + "-" + val[7] + val[8] + "-" + val[9] + val[10];
            }
            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value ?? string.Empty;
            string result = Regex.Replace(value.ToString(), "[^0-9]", "");
            if (result.Length > 11)
                result = result.Substring(0, 11);
            return result;
        }
    }
}
