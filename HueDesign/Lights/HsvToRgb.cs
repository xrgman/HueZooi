using HueDesign.Converters;
using HueDesign.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace HueDesign.Lights
{

    class HsvToRgbConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            HueLamp lamp = (HueLamp)value;
            return new SolidColorBrush( ColorUtil.HsvToRgb(lamp.Hue, lamp.Saturation, lamp.Brightness));

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Color color = (Color)value;
            double hue, sat, bri;
            ColorUtil.RGBtoHSV(color.R, color.G, color.B, out hue, out sat, out bri);
            return null;
        }


    }
}
