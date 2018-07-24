using System;
using WebClient.Models;
namespace WebClient.Interfaces
{
    public interface ITokenManager
    {
        string GenerateToken(UserInfo userInfo);
        string GenerateRefreshToken(string token);
        string ValidateRefreshToken(string token, string refreshToken);

    }
}