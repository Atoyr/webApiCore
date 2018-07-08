using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AuthorizationServer.Interfaces{
    public interface IOAuth
    {
        string RedirectUrl{set;get;} 
        string ResponseTypeErrorMessage{set;get;}
        Task<string> ResponseCodeAsync(IDictionary<string,string> values);
        Task<string> ResponseTokenAsync(IDictionary<string,string> values);
    }
} 