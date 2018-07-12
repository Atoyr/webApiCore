using System;
using System.Security.Cryptography;

namespace WebClient.Models
{
    public static class KeyGenerator
    {
        public static string GeneratKey()
        {
            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
            

        }
        
    }
    
}