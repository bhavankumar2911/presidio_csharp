using Microsoft.EntityFrameworkCore;
using RoleBasedAuthenticationAPI.Models;
using System.Drawing;

namespace RoleBasedAuthenticationAPI.Context
{
    public class RoleBasedAuthContext : DbContext
    {
        public RoleBasedAuthContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(p => p.Id);
        }
    }
}
