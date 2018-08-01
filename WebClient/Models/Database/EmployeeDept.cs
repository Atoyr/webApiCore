using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebClient.Models.Database
{
    [Table("EMPLOYEE_DEPT")]
    public class EmployeeDept : TableBase
    {
        [Column("COMPANY_ID")]
        public Guid CompanyId{set;get;}
        [Column("USER_ID")]
        public Guid UserId{set;get;}
        [Column("DEPT_ID")]
        public Guid DeptId{set;get;}
        [Column("ORDER")]
        public int Order{set;get;}
    }
}