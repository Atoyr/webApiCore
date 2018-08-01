using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("EMPLOYEE")]
    public class Employee : TableBase
    {
        [Column("COMPANY_ID")]
        public Guid CompanyId{set;get;}
        [Column("USER_ID")]
        public Guid UserId{set;get;}
        [Column("POSITION")]
        public string Position{set;get;}
    }
}