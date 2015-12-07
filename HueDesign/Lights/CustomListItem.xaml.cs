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
    public sealed partial class CustomListItem : ListViewItem
    {
        private HueLamp light;
        private Network network;

        public CustomListItem(HueLamp light, Network network)
        {
            this.InitializeComponent();
            this.light = light;
            this.network = network;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LightContentDialog.showLightDialog(light,network);

        }

        private async void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(0.02));
            network.SetLamp(light);
        }
    }
}
