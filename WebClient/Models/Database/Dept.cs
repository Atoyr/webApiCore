using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("DEPT")]
    public class Dept : TableBase
    {
        [Column("NAME")]
        public int Name{set;get;}
    }
}