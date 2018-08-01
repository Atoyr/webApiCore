using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    public abstract class TableBase
    {
        [Column("ID")]
        public Guid Id {set;get;}
        [Column("CREATE_USER")]
        public string CreateUser{set;get;}
        [Column("CREATE_DATETIME")]
        public DateTime CreateDateTime{set;get;}
        [Column("UPDATE_USER")]
        public string UpdateUser{set;get;}
        [Column("UPDATE_DATETIME")]
        public DateTime UpdateDateTime{set;get;}
    }
}