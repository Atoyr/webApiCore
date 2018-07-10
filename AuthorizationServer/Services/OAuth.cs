using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizationServer.Interfaces;
using AuthorizationServer.Models;


namespace AuthorizationServer.Services{
    public  class OAuth : IOAuth{
        public string RedirectUrl{set;get;} 
        public string ResponseTypeErrorMessage{set;get;}
        public Task<string> ResponseCodeAsync(IDictionary<string,string> values){
            return Task.Run(() => "CodeAsync");
        }
        public Task<string> ResponseTokenAsync(IDictionary<string,string> values){
            return Task.Run(() => "TokenAsync");
        }   
        public Task<string> ResponsePostAsync(IDictionary<string,string> values){
            return Task.Run(() => "PostAsync");
        }
        public Task<Token> ResponcePasswordAsync(IDictionary<string,string> values){
            return Task.Run(() => new Token());
        }
        public Task<Token> ResponceClientCredentialsAsync(IDictionary<string,string> values){
            return Task.Run(() => new Token());
        }
        public Task<Token> ResponceRefreshTokenAsync(IDictionary<string,string> values){
            return Task.Run(() => new Token());
        }
    }
}