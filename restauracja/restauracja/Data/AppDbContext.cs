using Microsoft.EntityFrameworkCore;
using restauracja.Models;

namespace restauracja.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Menu> Menu { get; set; }
    }
}
