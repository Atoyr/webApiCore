using System;

namespace WebClient.Models
{
    public class UserInfo
    {
        public Guid UserId{set;get;}
        public string UserName {set;get;}
        public byte[] Icon {set;get;}
    }
}