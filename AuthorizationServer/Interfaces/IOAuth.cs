using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizationServer.Models;

namespace AuthorizationServer.Interfaces{
    public interface IOAuth
    {
        string RedirectUrl{set;get;} 
        string ResponseTypeErrorMessage{set;get;}
        Task<string> ResponseCodeAsync(IDictionary<string,string> values);
        Task<string> ResponseTokenAsync(IDictionary<string,string> values);
        Task<string> ResponsePostAsync(IDictionary<string,string> values);
        Task<Token> ResponcePasswordAsync(IDictionary<string,string> values);
        Task<Token> ResponceClientCredentialsAsync(IDictionary<string,string> values);
        Task<Token> ResponceRefreshTokenAsync(IDictionary<string,string> values);
    }
} 