using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebClient.Models;
using WebClient.Interfaces;

namespace WebClient.Models.Sample
{
    public class TokenManager : ITokenManager
    {
        private IConfiguration _config;
        public TokenManager(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(UserInfo userInfo)
        {
    
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(100),
                signingCredentials: creds);
        
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}