using mba_application.ViewModels.Phone;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace mba_application.MBAComponents.MBAConverters
{
    class PhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (value as string).Length < 1)
                return value = "";
            string val = value.ToString();

            if (val[0] == '8')
            {
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
            }
            else
            {
                switch (val.Length)
                {
                    case 1: return val;
                    case 2: return val;
                    case 3: return val;
                    case 4: return val.Substring(0, 2) + "-" +  val[2] + val[3];
                    case 5: return val.Substring(0, 2) + "-" + val[2] + val[3] + "-" + val[4];
                    case 6: return val.Substring(0, 2) + "-" + val[2] + val[3] + "-" + val[4] + val[5];
                    case 7: return val.Substring(0, 3) + "-" + val[3] + val[4] + "-" + val[5] + val[6];
                    case 8: return "(" + val[0] + val[1] + val[2] + ") " + val[3] + val[4] + val[5] + "-" + val[6] + val[7];
                    case 9: return "(" + val[0] + val[1] + val[2] + ") " + val[3] + val[4] + val[5] + "-" + val[6] + val[7] + "-" + val[8];
                    case 10: return "(" + val[0] + val[1] + val[2] + ") " + val[3] + val[4] + val[5] + "-" + val[6] + val[7] + "-" + val[8] + val[9];
                    case 11: return val[0] + " (" + val[1] + val[2] + val[3] + ") " + val[4] + val[5] + val[6] + "-" + val[7] + val[8] + "-" + val[9] + val[10];
                }
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

    class PhoneStateToColorButtonCallConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = "#6CFF5F";
            PhoneState phoneStateVal = (PhoneState)Enum.Parse(typeof(PhoneState), value.ToString());

            switch (phoneStateVal)
            {
                case PhoneState.TRYING:
                case PhoneState.TRYING_IN:
                case PhoneState.CALL_ACCEPTS:
                    result = "#FF5F5F";
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class PhoneStateToHoverColorButtonCallConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = "#42DB59";
            PhoneState phoneStateVal = (PhoneState)Enum.Parse(typeof(PhoneState), value.ToString());

            switch (phoneStateVal)
            {
                case PhoneState.TRYING:
                case PhoneState.TRYING_IN:
                case PhoneState.CALL_ACCEPTS:
                    result = "Red";
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class PhoneStateToContentButtonCallConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PhoneState phoneStateVal = (PhoneState)Enum.Parse(typeof(PhoneState), value.ToString());

            switch (phoneStateVal)
            {
                case PhoneState.TRYING:
                case PhoneState.TRYING_IN:
                case PhoneState.CALL_ACCEPTS:
                    return new BitmapImage(new Uri("pack://application:,,,/mba-application;component/Resources/Images/Icons/endCallButtonImage.png"));
                default:
                    return new BitmapImage(new Uri("pack://application:,,,/mba-application;component/Resources/Images/Icons/callButtonImage.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class CallDurationToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timerStr = "";
            if ((int)value != 0)
            {
                int timer = Math.Abs((int)value);
                var r = TimeSpan.FromSeconds(timer);
                timerStr = timer > 3600 ? r.ToString(@"hh\:mm\:ss") : r.ToString(@"mm\:ss");
            }
            return timerStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
