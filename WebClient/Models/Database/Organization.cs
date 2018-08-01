using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("ORGANIZATION")]
    public class Organization : TableBase
    {
        [Column("NAME")]
        public string Name {set;get;}
        [Column("PARENT_ID")]
        public Guid ParentId {set;get;}
        [Column("ORDER")]
        public int Order{get;set;}
        [Column("COMP_ID")]
        public Guid CompId{set;get;}

        public virtual ICollection<Organization> Children{get;set;}
    }
}