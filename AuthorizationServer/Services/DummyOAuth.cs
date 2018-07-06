using System;
using AuthorizationServer.Interfaces;


namespace AuthorizationServer.Services{
    public class DummyOAuth : IOAuth{
       public string RedirectUrl{set;get;} = "http://localhost:5000/api/oauth2"; 
    }
}