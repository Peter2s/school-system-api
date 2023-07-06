using Microsoft.EntityFrameworkCore;
using school.Core.Models;

namespace school.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        }
        public DbSet<Student> students { get; set; }
    }
}
