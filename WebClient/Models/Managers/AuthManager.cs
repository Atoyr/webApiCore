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

        public UserInfo ReAuthentication(UserInfo userInfo)
        {
            var newUserInfo = _userManager.Find(userInfo.Id);
            Console.WriteLine(userInfo.Id);
            Console.WriteLine(userInfo.UpdateDateTime);
            Console.WriteLine(newUserInfo.Id);
            Console.WriteLine(newUserInfo.UpdateDateTime);
            if(newUserInfo.UpdateDateTime > userInfo.UpdateDateTime)
            {
                return default(UserInfo);
            }
            return _userManager.Find(userInfo.Id);
        }

        public UserInfo Authorization(LoginInfo loginInfo)
        {
            return _userManager.Find(loginInfo.Mail, loginInfo.Password);
        }
    }
}