using Day01.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Day01.Data.Context
{
    public class Appcontext : DbContext
    {
        public Appcontext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=MR-BOMBASTIC\\SQLEXPRESS;Initial catalog=Day01APIs;Integrated security=true;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Appcontext).Assembly);

            var productsList = new List<Product>
    {
        new Product { Id = 1, Title = "iPhone 15 Pro", Description = "128GB, Natural Titanium", Count = 10, Price = 999.99, CategoryId = 1 },
        new Product { Id = 2, Title = "Samsung Galaxy S24", Description = "256GB, Phantom Black", Count = 15, Price = 799.99, CategoryId = 1 },
        new Product { Id = 3, Title = "MacBook Air M3", Description = "13-inch, 8GB RAM, 256GB SSD", Count = 5, Price = 1099.00, CategoryId = 2 },
        new Product { Id = 4, Title = "Dell XPS 13", Description = "Intel Core i7, 16GB RAM", Count = 8, Price = 1250.50, CategoryId = 2 },
        new Product { Id = 5, Title = "Sony WH-1000XM5", Description = "Wireless Noise Canceling Headphones", Count = 20, Price = 349.99, CategoryId = 3 }
    };

            var categoriesList = new List<Category>
    {
        new Category { Id = 1, Name = "Smartphones" },
        new Category { Id = 2, Name = "Laptops & PCs" },
        new Category { Id = 3, Name = "Accessories" }
    };
            modelBuilder.Entity<Product>().HasData(productsList);
            modelBuilder.Entity<Category>().HasData(categoriesList);
            ; base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
