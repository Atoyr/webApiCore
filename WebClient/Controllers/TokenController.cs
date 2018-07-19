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
        public IActionResult GenerateToken([FromBody]LoginInfo loginInfo)
        {
            IActionResult response = Unauthorized();
            var userInfo = _authManager.Authorization(loginInfo);

            if(userInfo != null)
            {
                response = Ok(new {token = _tokenManager.GenerateToken(userInfo), refleshToken = KeyGenerator.GeneratKey()});
            }
            return response;
        }
        
        [Route("validate_token")]
        [HttpPost,Authorize]
        public IActionResult ValidateToken()
        {
            return Ok(); 
        }

        [Route("reflesh_token")]
        [HttpPost,Authorize(AuthenticationSchemes = Schemes.RefreshTokenScheme)]
        public IActionResult RefreshToken([FromForm]IDictionary<string,string> values)
        {
//            IActionResult response = Unauthorized();
            var currentUser = HttpContext.User;
            //Console.WriteLine(currentUser);
            foreach (var item in currentUser.Claims)
            {
                Console.WriteLine($"{item.Type} : {item.Value}");
            }
            //if( _authManager.CanRefresh)
            return Ok();
            //var userInfo = _authManager.Authorization()
        }
    }
}