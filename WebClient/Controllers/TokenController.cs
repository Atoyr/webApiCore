using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using WebClient.Interfaces;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private IAuthManager _authManager;
        private ITokenManager _tokenManager;

        public TokenController(IConfiguration config,ITokenManager tokenManager, IAuthManager authManager)
        {
            _config = config;
            _authManager = authManager;
            _tokenManager = tokenManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromForm]IDictionary<string,string> values)
        {
            IActionResult response = Unauthorized();
            var userInfo = _authManager.Authorization(_authManager.CreateLoginInfo(values));

            if(userInfo != null)
            {
                response = Ok(new {token = _tokenManager.GenerateToken(userInfo)});
            }
            return response;
        }
    }
}