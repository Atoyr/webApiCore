using System;

namespace WebClient.Models.Database
{
    [Table("AUTHORIZATION")]
    public class Authorization : TableBase
    {
        [Column("CODE")]
        public string Code {set;get;}
        [Column("NAME")]
        public string Name {set;get;}

    }
}