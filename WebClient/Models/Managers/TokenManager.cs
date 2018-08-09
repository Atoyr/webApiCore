using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using WebClient.Models;
using WebClient.Interfaces;
using System.Threading.Tasks;

namespace WebClient.Models.Managers
{
    public class TokenManager : ITokenManager
    {
        private IConfiguration _config;
        private IAuthManager _authManager;
        private IDictionary<string,string> _refreshTokenCollection;
        public TokenManager(IConfiguration config, IAuthManager authManager)
        {
            _refreshTokenCollection = new Dictionary<string, string>();
            _config = config;
            _authManager = authManager;
        }

        public string GenerateToken(UserInfo userInfo)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new [] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, userInfo.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.LastName),
                new Claim(JwtRegisteredClaimNames.Iat, GetUnixTimestamp().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerateTokenAsync(UserInfo userInfo)
        {
            return await Task.Run(() => GenerateToken(userInfo));
        }

        public string GenerateRefreshToken(string token)
        {
            var refreshToken = KeyGenerator.GeneratKey();
            _refreshTokenCollection.Add(token,refreshToken);
            return refreshToken;
        }

        public async Task<string> GenerateRefreshTokenAsync(string token)
        {
            return await Task.Run(() => GenerateRefreshToken(token));
        }

        public string ExecuteRefreshToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var id = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value;
            var email = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email)?.Value ?? string.Empty;
            var firstName = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.GivenName)?.Value ?? string.Empty;
            var lastName = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.FamilyName)?.Value ?? string.Empty;
            var updateDateTime = jsonToken.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Iat)?.Value ?? string.Empty;
            if(!string.IsNullOrEmpty(id))
            {
                var userInfo = new UserInfo{
                    Id = new Guid(id),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    UpdateDateTime = DateTime.Parse(updateDateTime)
                };
                _authManager.ReAuthentication(userInfo);
                if(userInfo != null)
                {
                    return GenerateToken(userInfo);
                }
            }
            return string.Empty;
        }

        public async Task<string> ExecuteRefreshTokenAsync(string token)
        {
            return await Task.Run(() => ExecuteRefreshToken(token));
        }

        public bool ValidateRefreshToken(string token, string refreshToken)
        {
            var currentPair = _refreshTokenCollection.FirstOrDefault(x => x.Key == token);
            return !currentPair.Equals( default(KeyValuePair<string,string>)) && currentPair.Value == refreshToken;
        }

        private double GetUnixTimestamp()
        {
            return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}