using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("USER")]
    public class User : TableBase
    {
        [Column("CODE")]
        public string Code{set;get;}
        [Column("NAME")]
        public string Name{set;get;}
        [Column("FIRST_NAME")]
        public string FirstName{set;get;}
        [Column("LAST_NAME")]
        public string LastName{set;get;}
        [Column("EMAIL")]
        public string Email{set;get;}
        [Column("HASH")]
        public string Hash{set;get;}
        [Column("SALT")]
        public byte[] Salt{set;get;}
        [Column("ICON")]
        public byte[] Icon{set;get;}

        public List<Employee> Employees {set;get;}
    }
}