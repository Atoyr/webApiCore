using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
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
            IActionResult response = Unauthorized();
            var headers = Request.Headers;
            var authNs = headers["Authorization"].FirstOrDefault()?.Split(' ');
            Console.WriteLine("RefreshToken");
            foreach(var str in authNs)
            {
                Console.WriteLine(str);
            }
            if(authNs.Count() == 2 && authNs[0] == "Bearer")
            {
                var jwt = authNs[1];
                var token = _tokenManager.ExecuteRefreshToken(jwt);
                var refreshToken = _tokenManager.GenerateRefreshToken(token);
                Console.WriteLine(jwt);
                Console.WriteLine(token);
                Console.WriteLine(refreshToken);
                response = Ok(new {token = token, refreshToken = refreshToken});
            }
            return response;
        }
    }
}