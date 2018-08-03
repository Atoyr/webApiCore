using System;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace WebClient.Models
{
    [DataContract]
    public class LoginInfo
    {
        [DataMember(Name="username")]
        public string Username {set;get;}
        [DataMember(Name="mail")]
        public string Mail{set;get;}
        [DataMember(Name="password")]
        public string Password {set;get;}
    }
}