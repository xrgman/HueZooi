using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class LightsPage : Page
    {
        public ObservableCollection<CustomListItem> Items { get; set; }
        public LightsViewModel lvm;
        private string connected;
        private SolidColorBrush connectColor;
        private Network network;

        public LightsPage()
        {
            this.InitializeComponent();
            Items = new ObservableCollection<CustomListItem>();
            connected = "Not Connected";
            connectColor = new SolidColorBrush(Colors.MediumVioletRed); 
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            network = (Network)e.Parameter;
            if (!(network.port == 0))
            {
                connected = "Connected";
                connectColor = new SolidColorBrush(Colors.Green);
                List<HueLamp> lights = await network.GetLamps();
                foreach (HueLamp light in lights)
                    Items.Add(new CustomListItem(light,network));
            }
        }

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (connected.Equals("connected"))
            {
                List<HueLamp> lights = await network.GetLamps();
                Items.Clear();
                foreach (HueLamp light in lights)
                    Items.Add(new CustomListItem(light, network));
            }
        }
    }
}
