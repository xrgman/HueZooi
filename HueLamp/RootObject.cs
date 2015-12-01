using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HueLamp
{
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string devicetype { get; set; }
    }

    [DataContract]
    public class RootLight
    {
        [DataMember]
        public bool on { get; set; }
        [DataMember]
        public int bri { get; set; }
        [DataMember]
        public int hue { get; set; }
        [DataMember]
        public int sat { get; set; }
    }
}
