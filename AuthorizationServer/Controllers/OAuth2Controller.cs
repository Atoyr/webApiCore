
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
            [FromQuery(Name="response_type")]string responseType,
            [FromQuery(Name="client_id")]string clientId,
            [FromQuery(Name="redirect_uri")]string redirectUri,
            [FromQuery(Name="scope")]string scope,
            [FromQuery(Name="state")]string state,
            [FromQuery(Name="code_challenge")]string codeChallenge,
            [FromQuery(Name="code_challege_method")]string codeChallegeMethod
        )
        {
            if(string.IsNullOrEmpty(responseType)) return null; 
            if(responseType.ToLower() ==  "code"){

            } else if (responseType.ToLower() ==  "token"){

            } else {
                return null;
            }
            //if (String.IsNullOrEmpty(response_type));
            string code = "hoge";
            return await Task.Run(() => $"{redirectUri ?? string.Empty}?code={code}&state={state}");
        }


        // POST api/oauth
        [HttpPost, Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> PostAsync([FromForm]TokenRequest value)
        {
            var param = new Dictionary<string,string>();
            param.Add("access_token","hoge"); 
            param.Add("token_type",value.grant_type);
            param.Add("expires_in",value.grant_type);
            param.Add("refresh_token",value.grant_type);
            param.Add("scope",value.grant_type);
            return await Task.Run(() => Json(param)); 
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
