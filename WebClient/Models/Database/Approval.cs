using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("APPROVAL")]
    public class Approval : TableBase
    {
        [Column("NO")]
        public string No{set;get;}
        [Column("COMP_ID")]
        public int CompId{set;get;}
        [Column("SLIP_NO")]
        public string SlipNo{set;get;}
        [Column("APPLICATION_DATETIME")]
        public DateTime ApplicationDateTime{set;get;}
    }
}