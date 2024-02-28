namespace DigiPhoto.Common
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class IntToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                switch (((int) value))
                {
                    case 0:
                        return false;

                    case 1:
                        return true;
                }
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

