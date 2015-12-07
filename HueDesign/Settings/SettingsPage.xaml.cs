using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace HueDesign.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private Network network;

        public SettingsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            network = (Network)e.Parameter;
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string ipAdress = IPInput.Text;
            int port = Int32.Parse(PortInput.Text);
            string username = UsernameInput.Text;
            Tuple<bool, string> connect = await network.Connect(ipAdress,port,username);
            if (connect.Item1)
            {
                ConnectStatusTextBlock.Text = "Connected";
            }
            else
            {
                if (connect.Item2.Equals("address"))
                    ConnectStatusTextBlock.Text = "Wrong ip adress or port";
                else if (connect.Item2.Equals("link"))
                    ConnectStatusTextBlock.Text = "Link button needs to be pushed";
            }
        }
    }
}
