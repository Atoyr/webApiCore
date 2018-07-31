using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebClient.Models.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<User>Users{get;set;}
    }
}