using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product_Category> ProductCategories { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product_Category>()
            .HasKey(k => new { k.ProductId, k.CategoryId });

        modelBuilder.Entity<ShoppingCart>()
            .HasKey(k => new { k.AccountId, k.ProductId });
        
        modelBuilder.Entity<Role>().HasData(new List<Role>()
        {
            new()
            {
                RoleId = 1,
                RoleName = "Admin"
            },
            new()
            {
                RoleId = 2,
                RoleName = "User"
            },
            new()
            {
                RoleId = 3,
                RoleName = "Guest"
            }
        });
        
        modelBuilder.Entity<Account>().HasData(new List<Account>()
        {
            new()
            {
                AccountId = 1,
                RoleId = 1,
                FirstName = "Mateusz",
                LastName = "Gorniak",
                Email = "mati.gorniak@gmail.com",
                Phone = "123456789"
            },
            new()
            {
                AccountId = 2,
                RoleId = 2,
                FirstName = "Tomasz",
                LastName = "Werner",
                Email = "tomi.werner@gmail.com",
                Phone = "987654321"
            },
            new()
            {
                AccountId = 3,
                RoleId = 3,
                FirstName = "Krzysztof",
                LastName = "Berteczko",
                Email = "krzysiu.barteczko@gmail.com",
                Phone = "456789123"
            }
        });
        
        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {
            new()
            {
                ProductId = 1,
                ProductName = "Product 1",
                ProductWidth = 2.1m,
                ProductHeight = 2.8m,
                ProductDepth = 1.3m
            },
            new()
            {
                ProductId = 2,
                ProductName = "Product 2",
                ProductWidth = 3m,
                ProductHeight = 5.4m,
                ProductDepth = 7.1m
            },
            new()
            {
                ProductId = 3,
                ProductName = "Product 3",
                ProductWidth = 2.1m,
                ProductHeight = 5.2m,
                ProductDepth = 3.9m
            }
        });
        
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>()
        {
            new()
            {
                AccountId = 1,
                ProductId = 1,
                Amount = 20
            },
            new()
            {
                AccountId = 2,
                ProductId = 3,
                Amount = 5
            },
            new()
            {
                AccountId = 3,
                ProductId = 2,
                Amount = 10
            }
        });
        
        modelBuilder.Entity<Category>().HasData(new List<Category>()
        {
            new()
            {
                CategoryId = 1,
                CategoryName = "Category 1"
            },
            new()
            {
                CategoryId = 2,
                CategoryName = "Category 2"
            },
            new()
            {
                CategoryId = 3,
                CategoryName = "Category 3"
            }
        });
        
        modelBuilder.Entity<Product_Category>().HasData(new List<Product_Category>()
        {
            new()
            {
                ProductId = 1,
                CategoryId = 1
            },
            new()
            {
                ProductId = 2,
                CategoryId = 2
            },
            new()
            {
                ProductId = 3,
                CategoryId = 3
            }
        });
        
    }
}