using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Context
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, Name = "Ramu", Experience = 2, Speciality = "Surgeon"},
                new Doctor() { Id = 2, Name = "Somu", Experience = 3.2, Speciality = "ETN" },
                new Doctor() { Id = 3, Name = "Komu", Experience = 8, Speciality = "Dermatology" }
                );
        }
    }
}
