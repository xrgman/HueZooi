using HueDesign.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HueDesign.Lights
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LightContentDialog : ContentDialog
    {
        private HueLamp light;
        private Network network;

        public LightContentDialog(HueLamp light, Network network)
        {
            this.InitializeComponent();
            this.light = light;
            this.network = network;
            this.DataContext = light;
        }

        public static async void showLightDialog(HueLamp light, Network network)
        {
            ContentDialog c = new LightContentDialog(light, network);
            await c.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            network.SetLamp(light);
            this.Hide();
        }

        private void HueSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            CurrentColor.Fill = new SolidColorBrush(ColorUtil.HsvToRgb(light.Hue, light.Saturation, light.Brightness));
        }
    }
}
