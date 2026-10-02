using Microsoft.EntityFrameworkCore;
using StudentRosterDbApi.Models;

namespace StudentRosterDbApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet represents a table in the database
        public DbSet<Student> Students { get; set; }
    }
}