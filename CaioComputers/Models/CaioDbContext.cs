using System.Data.Entity;

namespace CaioComputers.Models
{
    public class CaioDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}