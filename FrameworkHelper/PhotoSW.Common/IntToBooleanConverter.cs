using System;
using System.Globalization;
using System.Windows.Data;

namespace PhotoSW.Common
{
	public class IntToBooleanConverter : IValueConverter
	{
		public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			object result;
			if (value is int)
			{
				int num = (int)value;
				if (num == 0)
				{
					result = false;
					return result;
				}
				if (num == 1)
				{
					result = true;
					return result;
				}
			}
			result = true;
			return result;
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new System.NotImplementedException();
		}
	}
}
