using System;
using System.Linq;
using System.Collections.Generic;
using WebClient.Interfaces;

namespace WebClient.Models.Managers
{
    public class AuthManager : IAuthManager
    {

        public UserInfo Authorization(LoginInfo loginInfo)
        {
            return new UserInfo{UserName = $"Id : {loginInfo.Username}" ,UserId = loginInfo.Username};
        }
        public LoginInfo CreateLoginInfo(string username, string password)
        {
            return new LoginInfo{Username= username, Password = password};
        }
    }
}