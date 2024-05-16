using Microsoft.EntityFrameworkCore;
using PizzaAPI.Models;
using System.Numerics;

namespace PizzaAPI.Context
{
    public class PizzaShopContext : DbContext
    {
        public PizzaShopContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { Id = 1, Name = "Italian Pizza", BasePrice = 99, Size = Size.Small, Stock = 120},
                new Pizza() { Id = 2, Name = "Brick Oven Pizza", BasePrice = 199, Size = Size.Regular, Stock = 40 },
                new Pizza() { Id = 3, Name = "Sicilian Pizza", BasePrice = 99, Size = Size.Large, Stock = 20 }
            );
        }
    }
}
