using HueDesign.Lights;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace HueDesign
{
    public  class Network
    {
        private string ipAdress, username, hueUsername;
        public int port { get; set; }
        private HttpClient client;

        public Network()
        {
            this.client = new HttpClient();
        }


        public async Task<Tuple<bool, string>> Connect(string ipAdress, int port, string username)
        {
            RootObject contents = new RootObject()
            {
                devicetype = ($"MijnApp#{username}")
            };
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(contents), Encoding.UTF8, "application/json");
                var login = await client.PostAsync($"http://{ipAdress}:{port}/api/", content);
                string result = await login.Content.ReadAsStringAsync();
                string[] splittedResult = result.Split('"');
                string hueUsername = splittedResult[5];
                if (String.IsNullOrEmpty(hueUsername) || hueUsername.Equals("address"))
                {
                    Reset();
                    return new Tuple<bool, string>(false, "link");
                }
                else
                {
                    this.ipAdress = ipAdress;
                    this.port = port;
                    this.username = username;
                    this.hueUsername = hueUsername;
                    return new Tuple<bool, string>(true, "none"); ;
                }
            }
            catch (Exception e)
            {
                Reset();
                return new Tuple<bool, string>(false, "address");
            }
        }

        private void Reset()
        {
            this.ipAdress = "";
            this.port = 0;
            this.username = "";
        }

        public async Task<List<HueLamp>> GetLamps()
        {
            var allData = await client.GetAsync($"http://{ipAdress}:{port}/api/{hueUsername}/lights");
            string result = await allData.Content.ReadAsStringAsync();
            List<HueLamp> lights = ExtractLights(result);
            return lights;
        }


        private List<HueLamp> ExtractLights(string json)
        {
            List<HueLamp> lamps = new List<HueLamp>();
            JsonObject lights;
            if (!JsonObject.TryParse(json, out lights))
                System.Diagnostics.Debug.WriteLine("Error: " + json);
            foreach (string lightId in lights.Keys)
            {
                JsonObject light = lights.GetNamedObject(lightId, null);
                string name = light.GetNamedString("name", string.Empty);
                light = light.GetNamedObject("state", null);
                if (light != null)
                {
                    HueLamp hueLamp = new HueLamp(
                            name,
                            Convert.ToInt32(lightId),
                            Convert.ToInt32(light.GetNamedNumber("hue", 0)),
                            Convert.ToInt32(light.GetNamedNumber("bri", 0)),
                            Convert.ToInt32(light.GetNamedNumber("sat", 0)),
                            light.GetNamedBoolean("on", false)
                        );
                    lamps.Add(hueLamp);
                }
            }
            return lamps.OrderBy(x => x.Id).ToList();
        }

        public async void SetLamp(HueLamp hueLamp)
        {
            RootLight light = new RootLight()
            {
                on = hueLamp.On,
                hue = Convert.ToInt32(hueLamp.Hue),
                sat = Convert.ToInt32(hueLamp.Saturation),
                bri = Convert.ToInt32(hueLamp.Brightness)
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(light), Encoding.UTF8, "application/json");
            var setter = await client.PutAsync($"http://{ipAdress}:{port}/api/{hueUsername}/lights/{hueLamp.Id}/state", content);
        }

        public void SendAllLamps(List<HueLamp> lights)
        {
            foreach (HueLamp light in lights)
                SetLamp(light);
        }
    }
}
