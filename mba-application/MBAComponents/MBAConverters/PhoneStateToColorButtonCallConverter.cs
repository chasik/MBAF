using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace mba_application.MBAComponents.MBAConverters
{
    class PhoneStateToColorButtonCallConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = "#6CFF5F";
            ViewModels.PhoneState phoneStateVal = (ViewModels.PhoneState)Enum.Parse(typeof(ViewModels.PhoneState), value.ToString());

            switch (phoneStateVal)
            {
                case ViewModels.PhoneState.OutgoingCall: result = "#FF5F5F";
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
            ViewModels.PhoneState phoneStateVal = (ViewModels.PhoneState)Enum.Parse(typeof(ViewModels.PhoneState), value.ToString());

            switch (phoneStateVal)
            {
                case ViewModels.PhoneState.OutgoingCall:
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
            BitmapImage result;

            ViewModels.PhoneState phoneStateVal = (ViewModels.PhoneState)Enum.Parse(typeof(ViewModels.PhoneState), value.ToString());

            switch (phoneStateVal)
            {
                case ViewModels.PhoneState.OutgoingCall:
                    result = new BitmapImage(new Uri("pack://application:,,,/mba-application;component/Resources/Images/Icons/endCallButtonImage.png"));
                    break;
                default:
                    result = new BitmapImage(new Uri("pack://application:,,,/mba-application;component/Resources/Images/Icons/callButtonImage.png"));
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
