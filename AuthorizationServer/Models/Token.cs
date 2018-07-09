using System;

namespace AuthorizationServer.Models{
    public class Token{
        public string Key{set;get;}
        public string AccessToken{set;get;}
        public string TokenType{set;get;}
        public string RefreshToken{set;get;}
        public string Scope{set;get;}
    }
}