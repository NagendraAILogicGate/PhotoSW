using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PhotoSW.Orders
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result;
            while (true)
            {
                bool arg_12_0 = value.GetType() != typeof(bool);
                bool arg_1E_0;
                do
                {
                    bool expr_12 = arg_12_0 = (arg_1E_0 = !arg_12_0);
                    if (!false)
                    {
                        bool flag = expr_12;
                        arg_1E_0 = (arg_12_0 = flag);
                    }
                }
                while (false);
                if (!arg_1E_0)
                {
                    break;
                }
                Visibility arg_3E_0;
                if (!(bool)value)
                {
                    arg_3E_0 = Visibility.Hidden;
                }
                else
                {
                    if (false)
                    {
                        break;
                    }
                    arg_3E_0 = Visibility.Visible;
                }
            IL_3A:
                if (2 != 0)
                {
                    result = arg_3E_0;
                    if (3 != 0)
                    {
                        return result;
                    }
                    continue;
                }
                goto IL_3A;
            }
            result = Visibility.Hidden;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
