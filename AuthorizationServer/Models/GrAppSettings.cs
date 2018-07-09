using System;
using AuthorizationServer.Interfaces;

namespace AuthorizationServer.Models{
    public class GrAppSetting: IAppSettings
    {
       public Emp Emp {get;set;} 
    }

    public class Emp{
        public string EmpCore {get;set;}
    }
}