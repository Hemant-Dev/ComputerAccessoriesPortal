using ComputerAccessories.Model;
using Microsoft.EntityFrameworkCore;

namespace ComputerAccessories.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Mouse> Mouses { get; set; }
    }

    
}
