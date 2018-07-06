

namespace Api
{
    public interface IApi
    {
        bool Auth(string key);
        bool Auth(string userId,string password);
    }

    public static class IApiEx
    {
        static string GenerateKey(this IApi api)
        {
            return string.Empty;
        }
    }
}