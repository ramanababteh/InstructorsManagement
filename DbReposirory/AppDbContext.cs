using DbReposirory.Models;
using Microsoft.EntityFrameworkCore;

namespace DbReposirory
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Instructor> Instructors { get; set; }
    }
}
