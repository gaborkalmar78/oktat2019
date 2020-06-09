using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>opt)
            : base(opt)
        {
            Database.Migrate();
        }
        public DbSet<Models.User> Users { get; set; }
    }
}
