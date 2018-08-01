using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("APPROVAL_ROUTE")]
    public class ApprovalRoute : TableBase
    {
        [Column("NAME")]
        public string Name {set;get;}
        [Column("COMP_ID")]
        public Guid CompId{set;get;}
    }
}