using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Data.Json;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HueLamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
      
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            Network network = new Network();
            if (await network.Connect(ServerIpTextBox.Text, Int32.Parse(ServerPortTextBox.Text), "Wesley"))
            {
                System.Diagnostics.Debug.WriteLine("succes");
                Frame.Navigate(typeof(LampOverviewPage), network);
            }
            else
                System.Diagnostics.Debug.WriteLine("link button moet ingedrukt worde");    
        }
    }
}
