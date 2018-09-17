using System;
using WebClient.Models;

namespace WebClient.Interfaces
{
    public interface IUserManager
    {
        UserInfo Find(Guid userId);
        UserInfo Find(string mail,string password);
        bool CreateUser(
            string code,
            string name,
            string mail,
            string password,
            byte[] icon,
            string createUser);
        byte[] GetUserIcon(Guid userId);
    }
}