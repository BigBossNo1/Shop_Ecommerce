using Shop.Models.Models;
using System.Data.Entity;

namespace Shop.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("ShopDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrrderDetals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategorye> ProductCategoryes { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}