using System;
using System.Threading.Tasks;
using AuthorizationServer.Interfaces;


namespace AuthorizationServer.Services{
    public class DummyOAuth : IOAuth{
        public string RedirectUrl{set;get;} = "http://localhost:5000/api/oauth2"; 
        public string ResponseTypeErrorMessage{set;get;} = "Not Setting ResponseType";
        public Task<string> ResponseCodeAsync(){
            return Task.Run(() => "CodeAsync");
        }
        public Task<string> ResponseTokenAsync(){
            return Task.Run(() => "TokenAsync");
        }
    }
}