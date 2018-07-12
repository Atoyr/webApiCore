using System;
using System.Linq;
using System.Collections.Generic;
using WebClient.Interfaces;

namespace WebClient.Models.Sample
{
    public class AuthManager : IAuthManager
    {

        public UserInfo Authorization(LoginInfo loginInfo)
        {
            return new UserInfo{UserName = $"Id : {loginInfo.Id}" ,UserId = loginInfo.Id};
        }
        public LoginInfo CreateLoginInfo(IDictionary<string,string> values)
        {
            var id = values.FirstOrDefault(x => x.Key == "username").Value ?? string.Empty;
            var password = values.FirstOrDefault(x => x.Key == "password").Value ?? string.Empty;
            return new LoginInfo{Id = id, Password = password};
        }
    }
}