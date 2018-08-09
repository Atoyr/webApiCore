using System;

namespace WebClient.Models
{
    public class UserInfo
    {
        public Guid Id{set;get;}
        public string Code {set;get;}
        public string Name {set;get;}
        public string FirstName {set;get;}
        public string LastName {set;get;}
        public string Email {set;get;}
        public DateTime UpdateDateTime {set;get;}
    }
}