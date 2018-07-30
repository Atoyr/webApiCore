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
    public class ProfileController : Controller
    {
        private IConfiguration _config;

        public ProfileController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult GenerateToken([FromBody]LoginInfo loginInfo)
        {
            IActionResult response = Unauthorized();

            return response;
        }

        [Route("validate_token")]
        [HttpPost,Authorize]
        public IActionResult ValidateToken()
        {
            return Ok();
        }

    }
}