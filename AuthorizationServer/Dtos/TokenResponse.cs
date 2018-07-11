using System;
using System.Runtime.Serialization;

namespace AuthorizationServer.Dtos
{
    [DataContract]
    public class TokenResponse{
        [DataMember(Name="response_type")]
        public string ResponseType{set;get;}

        [DataMember(Name="access_token")]
        public string AccessToken{set;get;}
        [DataMember(Name="code")]
        public string Code{set;get;}
        [DataMember(Name="id_token")]
        public string IdToken{set;get;}

        [DataMember(Name="token_type")]
        public string TokenType{set;get;}
        [DataMember(Name="expires_in")]
        public string ExpiresIn{set;get;}
        [DataMember(Name="refresh_token")]
        public string RefreshToken{set;get;}
        [DataMember(Name="scope")]
        public string Scope{set;get;}
    }
}