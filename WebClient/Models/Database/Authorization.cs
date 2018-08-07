using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("AUTHORIZATION")]
    public class Authorization : TableBase
    {
        [Column("COMPANY_ID")]
        public Guid CompanyId {set;get;}
        [Column("USER_ID")]
        public Guid UserId {set;get;}
        [Column("VALUE")]
        public int Value {set;get;}
    }
}