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
            var cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            int port = Int32.Parse(ServerPortTextBox.Text);
            string ipAdress = ServerIpTextBox.Text;
            string username = "Wesley";
            HttpClient client = new HttpClient();
            RootObject contents = new RootObject()
            {
                devicetype = ($"MijnApp#{username}")
            }; 
            HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8,"application/json");
            var login = await client.PostAsync($"http://{ipAdress}:{port}/api/",content);
            var result = await login.Content.ReadAsStringAsync();




            System.Diagnostics.Debug.WriteLine(result.ToString());

            JsonObject json;
            
    

            bool parseOk = JsonObject.TryParse(result, out json);
            if (parseOk)
                System.Diagnostics.Debug.WriteLine(json);
            else
                System.Diagnostics.Debug.WriteLine("goi");



            //var response = await client.GetAsync($"http://{ipAdress}:{port}/api/b918a361eb708cbc4e7b001c7013c27");

            //var result = await response.Content.ReadAsStringAsync();
            //var serializer = DataContractJsonSerializer(typeof(RootObject));
            //System.Diagnostics.Debug.WriteLine(result.ToString());


            // Frame.Navigate(typeof(LampOverviewPage));
        }

       
    }
}
