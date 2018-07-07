using System;
using System.Threading.Tasks;

namespace AuthorizationServer.Interfaces{
    public interface IOAuth
    {
        
        string RedirectUrl{set;get;} 
        string ResponseTypeErrorMessage{set;get;}
        Task<string> ResponseCodeAsync();
        Task<string> ResponseTokenAsync();
    }
} 