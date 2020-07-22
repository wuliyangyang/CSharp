using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YY.WCF.Models
{
    [DataContract]
    public class User
    {
        public User()
        { }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Num { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
