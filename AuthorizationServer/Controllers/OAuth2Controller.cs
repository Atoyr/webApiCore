
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.WebUtilities.QueryHelpers; 
using AuthorizationServer.Interfaces; 
using AuthorizationServer.Models;

namespace AuthorizationServer.Controllers
{
    [Route("api/[controller]")]
    public class OAuth2Controller : Controller
    {
        private readonly IOAuth _context;
        public OAuth2Controller(IOAuth context)
        {
            _context = context;
        }
        // GET api/oauth
        [HttpGet]
        public async Task<string> GetAsync(
            [FromQuery]IDictionary<string,string> value
        )
        {
            var responseType = value.ContainsKey("response_type") ? value["response_type"] : String.Empty; 
            if(string.IsNullOrEmpty(responseType)) return _context.ResponseTypeErrorMessage; 
            if(responseType.ToLower() ==  "code"){
                return await _context.ResponseCodeAsync(value);
            } else if (responseType.ToLower() ==  "token"){
                return await _context.ResponseTokenAsync(value);
            } else {
                return null;
            }
        }


        // POST api/oauth
        [HttpPost, Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> PostAsync([FromForm]IDictionary<string,string> value)
        {
            var grantType = value.ContainsKey("grant_type") ? value["grant_type"] : String.Empty;
            if(string.IsNullOrEmpty(grantType)) return BadRequest();
            return await Task.Run(() => Json(_context.ResponsePostAsync(value))); 
        }
    }
}
