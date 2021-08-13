using EShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.DAL
{
    public class EShopContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderItem>  OrderItems { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        
        public EShopContext() { }

        public EShopContext(DbContextOptions<EShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EShopDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Order)
                    .WithOne(x => x.User);       
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.OrderItems)
                    .WithOne(x => x.Order);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(x => x.ProductCategory)
                    .WithOne(x => x.Product);
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(x => x.Id);
            });
        }
    }
}