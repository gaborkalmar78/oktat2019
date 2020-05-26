using Microsoft.EntityFrameworkCore;
using project_021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_021.DataBase
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {

        }
        public DbSet<Topic> Topics { get; set; }
    }
}
