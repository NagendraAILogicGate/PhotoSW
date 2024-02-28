using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PhotoSW.Common
{

    public class FindCommandParametersConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            FindCommandParameters findCommandParameters;
            while (true)
            {
            IL_00:
                while (true)
                {
                IL_01:
                    findCommandParameters = new FindCommandParameters();
                    if (!false)
                    {
                        findCommandParameters.Text = values[0].ToString();
                    }
                    while (8 != 0)
                    {
                        findCommandParameters.IgnoreCase = values[1].ToString();
                        if (3 != 0)
                        {
                            if (2 == 0)
                            {
                                goto IL_00;
                            }
                            if (6 != 0)
                            {
                                break;
                            }
                            goto IL_01;
                        }
                    }
                    return findCommandParameters;
                }
            }
            return findCommandParameters;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
