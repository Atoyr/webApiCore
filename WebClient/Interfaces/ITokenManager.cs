using System;
using WebClient.Models;
using System.Threading.Tasks;
namespace WebClient.Interfaces
{
    public interface ITokenManager
    {
        string GenerateToken(UserInfo userInfo);
        string GenerateRefreshToken(string token);
        Task<string> GenerateTokenAsync(UserInfo userInfo);
        Task<string> GenerateRefreshTokenAsync(string token);
        bool ValidateRefreshToken(string token, string refreshToken);
        string ExecuteRefreshToken(string token);
        Task<string> ExecuteRefreshTokenAsync(string token);
    }
}