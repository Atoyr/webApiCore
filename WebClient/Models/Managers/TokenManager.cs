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
        private IDictionary<string,string> _refreshTokenCollection;
        public TokenManager(IConfiguration config)
        {
            _refreshTokenCollection = new Dictionary<string,string>();
            _config = config;
        }
        public string GenerateToken(UserInfo userInfo)
        {
            return GenerateToken();
        }

        public Task<string> GenerateTokenAsync(UserInfo userInfo)
        {
            return Task.Run(() => GenerateToken(userInfo));
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

        public string ExecuteRefreshToken()
        {
            return GenerateToken();
        }

        public async Task<string> ExecuteRefreshTokenAsync()
        {
            return await Task.Run(() => ExecuteRefreshToken());
        }

        public bool ValidateRefreshToken(string token, string refreshToken)
        {
            var currentPair = _refreshTokenCollection.FirstOrDefault(x => x.Key == token);
            return !currentPair.Equals( default(KeyValuePair<string,string>)) && currentPair.Value == refreshToken;
        }
        private string GenerateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}