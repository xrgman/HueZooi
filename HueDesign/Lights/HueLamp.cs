using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HueDesign.Lights
{
    public class HueLamp
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Hue { get; set; }
        public double Brightness { get; set; }
        public double Saturation { get; set; }
        public bool On { get; set; }

        public HueLamp(string Name, int Id, int Hue, int Brightness, int Saturation, bool On)
        {
            this.Name = Name;
            this.Id = Id;
            this.Hue = Hue;
            this.Brightness = Brightness;
            this.Saturation = Saturation;
            this.On = On;
        }
    }
}
