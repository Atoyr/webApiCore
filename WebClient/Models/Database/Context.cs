using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebClient.Models.Database
{
    public class Context : DbContext
    {
        public Context()
        { }
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<User>Users{get;set;}
        public DbSet<Company>Companys{get;set;}
        public DbSet<Employee>Employees{get;set;}
        public DbSet<Approval>Approvals{get;set;}
        public DbSet<ApprovalRoute>ApprovalRoutes{get;set;}
        public DbSet<Organization>Organization{get;set;}
        public DbSet<Authorization>Authorizations{get;set;}
    }
}