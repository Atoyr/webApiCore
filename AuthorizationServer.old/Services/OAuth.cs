using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AuthorizationServer.Interfaces;


namespace AuthorizationServer.Services{
    public  class OAuth : IOAuth{
        public string RedirectUrl{set;get;} 
        public string ResponseTypeErrorMessage{set;get;}
        public Task<string> ResponseCodeAsync(IDictionary<string,string> values){
            return Task.Run(() => "CodeAsync");
        }
        public Task<string> ResponseTokenAsync(IDictionary<string,string> values){
            return Task.Run(() => "TokenAsync");
        }   }
}