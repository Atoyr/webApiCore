using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("COMPANY")]
    public class Company : TableBase
    {
        [Column("CODE")]
        public string Code {set;get;}
        [Column("NAME")]
        public string Name {set;get;}
        [Column("ADDRESS")]
        public string Address {set;get;}

        public List<Employee> Employees {set;get;}
        public List<Organization> Organizations {set;get;}
    }
}