using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Models.Sample
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<User>Users{get;set;}
    }
}