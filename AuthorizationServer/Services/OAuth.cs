using System;
using AuthorizationServer.Interfaces;


namespace AuthorizationServer.Services{
    public  class OAuth : IOAuth{
       public string RedirectUrl{set;get;} 
    }
}