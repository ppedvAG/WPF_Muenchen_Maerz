using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MultiBinding_ColorPicker
{
    public class DoublesToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            byte r=0, g=0, b=0;

            if(values[0] is double dred)
            {
                r = (byte)dred;
            }
            
            if (values[1] is double dgreen)
            {
                g = (byte)dgreen;
            }
            if (values[2] is double dblue)
            {
                b = (byte)dblue;
            }

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
