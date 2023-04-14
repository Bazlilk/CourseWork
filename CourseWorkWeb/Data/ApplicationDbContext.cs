using CourseWorkWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
        public DbSet<Requests> Requests { get; set; }
    }
}
