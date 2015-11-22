using System;
using System.Globalization;
using System.Windows.Data;

using mba_application.MBAImportService;

namespace mba_application.MBAComponents.MBAConverters
{
    public class MultiBindConverter : IMultiValueConverter
    {
        public MultiBindConverter()
        {

        }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //return new GoodColumnAddRelationParamDC { GoodColumn = (values[0] as GoodColumnDC), ColumnHeader = (values[1] as string) };
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
