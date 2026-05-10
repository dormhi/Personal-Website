using Microsoft.EntityFrameworkCore;
using PersonalWebSite.Models;

namespace PersonalWebSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
