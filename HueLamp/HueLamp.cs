using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HueLamp
{
    class HueLamp
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Hue { get; set; }
        public int Brightness { get; set; }
        public int Saturation { get; set; }
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
