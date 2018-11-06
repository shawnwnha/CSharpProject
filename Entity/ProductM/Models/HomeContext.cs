using Microsoft.EntityFrameworkCore;

namespace ProductM.Models{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }
        public DbSet<Product> products {get;set;} 
        public DbSet<Category> categories {get;set;} 
        public DbSet<ProCat> product_category {get;set;} 
    }
}