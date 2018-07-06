using System;

namespace AuthorizationServer.Models{
    public class TokenRequest{
        public string grant_type {set;get;}
        public string code {set;get;}
        public string redirect_uri {set;get;}
        public string code_verifire {set;get;}
        public string client_id {set;get;}
    }
}