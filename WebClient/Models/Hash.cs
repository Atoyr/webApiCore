using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WebClient.Models
{
    public static class Hash
    {
        public static string GetHash(
            string targetStr,
            byte[] salt,
            KeyDerivationPrf keyDerivationPrf,
            int iterationCount = 1000,
            int numBytesRequested = 256 / 8
        )
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: targetStr,
                    salt: salt,
                    prf: keyDerivationPrf,
                    iterationCount: iterationCount,
                    numBytesRequested: numBytesRequested
                )
            );
        }

        public static byte[] GenerateSalt(int length = 128 / 8)
        {
            var salt = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }

}