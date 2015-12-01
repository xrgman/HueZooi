using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;


namespace HueLamp
{
    public class HsvToRgb : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                HueLamp lamp = (HueLamp)value;
                int hue = lamp.Hue;
                int sat = lamp.Saturation;
                int bri = lamp.Brightness;
                int r, g, b;

            }
            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //hoi;
            return null;
        }
    }
}
