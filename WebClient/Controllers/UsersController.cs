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
using System.Linq;
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

        [HttpGet, Authorize]
        public async Task<IActionResult> GetUsersAsync()
        {
            return await Task.Run(() => {
                IActionResult response = Unauthorized();
                return response;
            });
        }

        public async Task<IActionResult> GetUserAsync()
        {
            return await Task.Run(() => {
                IActionResult response = Unauthorized();
                return response;
            });
        }

        public async Task<IActionResult> GetUserIconAsync([FromQuery]Guid id)
        {
            return await Task.Run(() => {
                IActionResult response = Unauthorized();
                var icon = _userManager.GetUserIcon(id);
                if(icon != null)
                {
                    response = File(icon,"image/jpg");
                }
                return response;
            });
        }

        [Route("create_user")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody]Dictionary<string,string> args)
        {
            var code = args.FirstOrDefault(x => x.Key == "code").Value;
            var name = args.FirstOrDefault(x => x.Key == "name").Value;
            var mail = args.FirstOrDefault(x => x.Key == "mail").Value;
            var password = args.FirstOrDefault(x => x.Key == "password").Value;
            _userManager.CreateUser(code, name, mail, password, null, name);
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