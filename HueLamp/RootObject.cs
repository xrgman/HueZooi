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
        [DataMember]
        public string username { get; set; }


        public override string ToString()
        {
            return "user: " + username;
        }
    }
}
