using forumTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forumTest.Data
{
    public class ForumsContext : DbContext
    {

        public ForumsContext(DbContextOptions<ForumsContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> comments { get; set; }
        public DbSet<Post> posts { get; set; }
    }
}
