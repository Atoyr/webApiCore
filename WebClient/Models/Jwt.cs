using System;

namespace WebClient.Models
{
    public class Jwt
    {
        public string Key{set;get;}
        public string Issuer {set;get;}
        public string Audience {set;get;}
    }
}