using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace YY.SOA.WebService.Models
{
    [DataContract]
    public class User
    {
        public User()
        { }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public string MobileNumber { get; set; }
    }
}