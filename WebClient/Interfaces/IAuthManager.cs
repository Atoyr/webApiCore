using System;
using System.Collections.Generic;
using WebClient.Models;

namespace WebClient.Interfaces
{
    public interface IAuthManager
    {
        UserInfo Authorization(LoginInfo loginInfo);
    }
}