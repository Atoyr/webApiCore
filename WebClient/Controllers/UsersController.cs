using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Interfaces;
using WebClient.Models;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [Route("users")]
        [HttpGet, Authorize]
        public async Task<IActionResult> GetUsersAsync()
        {
            return await Task.Run(() => {
                IActionResult response = Unauthorized();
                return response;
            });
        }

        [Route("create_user")]
        [HttpPost,Authorize]
        public async Task<IActionResult> CreateUserAsync([FromBody]Dictionary<string,string> args)
        {
            foreach(var arg in args)
            {
                Console.WriteLine($"key {arg.Key} ; value {arg.Value}");
            }
            return await Task.Run(() => {
                return Ok();
            });
        }
        [Route("update_user")]
        [HttpPost,Authorize]
        public async Task<IActionResult> UpdateUserAsync([FromBody]Dictionary<string,string> args)
        {
            return await Task.Run(() => {
                return Ok();
            });
        }
    }
}