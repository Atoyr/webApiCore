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
using WebClient.Models;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GenerateTokenAsync([FromBody]LoginInfo loginInfo)
        {
            IActionResult response = Unauthorized();
            var userInfo = _authManager.Authorization(loginInfo);
            if(userInfo != null)
            {
            Console.WriteLine(userInfo?.UserName);
                var token = await _tokenManager.GenerateTokenAsync(userInfo);
                var refreshTokenTask = _tokenManager.GenerateRefreshTokenAsync(token);
                response = Ok(new {token = token, refreshToken = await refreshTokenTask});
            }
            return response;
        }

        [Route("validate_token")]
        [HttpPost,Authorize]
        public IActionResult ValidateToken()
        {
            return Ok();
        }

        [Route("refresh_token")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RefreshToken([FromBody]string values)
        {
            Console.WriteLine(values);
            var headers = Request.Headers;
            IActionResult response = Unauthorized();
            if(!string.IsNullOrEmpty(headers["Authorization"]))
            {
                var token = _tokenManager.ExecuteRefreshToken();
                var refreshToken = _tokenManager.GenerateRefreshToken(token);
                response = Ok(new {token = token, refreshToken = refreshToken});
            }
            return response;
        }
    }
}