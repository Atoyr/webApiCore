using System;
using System.Linq;
using System.Collections.Generic;
using WebClient.Interfaces;

namespace WebClient.Models.Managers
{
    public class AuthManager : IAuthManager
    {
        private IUserManager _userManager;

        public AuthManager(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public UserInfo Authentication(LoginInfo loginInfo)
        {
            return _userManager.Find(loginInfo.Mail, loginInfo.Password);
        }
        public UserInfo Authorization(LoginInfo loginInfo)
        {
            return _userManager.Find(loginInfo.Mail, loginInfo.Password);
        }
    }
}