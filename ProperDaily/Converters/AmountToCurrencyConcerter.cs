using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDaily.Converters
{
    public class AmountToCurrencyConcerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isIcome = ((Label) parameter).Text;
            var amount = (decimal)value;
            if (isIcome == "True")
            {
                return $"+ {amount:C}";
            }
            else
            {
                return $"- {amount:C}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
