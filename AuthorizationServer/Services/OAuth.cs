using System;
using System.Threading.Tasks;
using AuthorizationServer.Interfaces;


namespace AuthorizationServer.Services{
    public  class OAuth : IOAuth{
        public string RedirectUrl{set;get;} 
        public string ResponseTypeErrorMessage{set;get;}
        public Task<string> ResponseCodeAsync(){
            return Task.Run(() => "CodeAsync");
        }
        public Task<string> ResponseTokenAsync(){
            return Task.Run(() => "TokenAsync");
        }   }
}