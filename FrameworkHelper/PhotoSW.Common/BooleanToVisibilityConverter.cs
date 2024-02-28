using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PhotoSW.Common
{
	public sealed class BooleanToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			object result;
			if (value is bool)
			{
				result = (((bool)value) ? Visibility.Visible : Visibility.Collapsed);
			}
			else
			{
				result = value;
			}
			return result;
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new System.NotImplementedException();
		}
	}
}
