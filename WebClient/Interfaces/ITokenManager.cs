using System;
using WebClient.Models;
namespace WebClient.Interfaces
{
    public interface ITokenManager
    {
        string GenerateToken(UserInfo userInfo);

    }
}