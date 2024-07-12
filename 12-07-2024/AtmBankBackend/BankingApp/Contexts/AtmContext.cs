using BankingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Contexts
{
    public class AtmContext : DbContext
    {
        public AtmContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Atm> Atms { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Card> Cards { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
               .HasOne(t => t.Account)
               .WithMany(a => a.Transactions)
               .HasForeignKey(t => t.AccountId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Transaction>()
               .HasOne(t => t.Card)
               .WithMany(c => c.TransactionList)
               .HasForeignKey(t => t.CardNumber)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Transaction>()
               .HasOne(t => t.Atm)
               .WithMany(a => a.Transactions)
               .HasForeignKey(t => t.AtmId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            // Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Phone = "123-456-7890", Address = "123 Main St" },
                new User { Id = 2, Name = "Jane Smith", Phone = "987-654-3210", Address = "456 Elm St" },
                new User { Id = 3, Name = "Alice Johnson", Phone = "555-555-5555", Address = "789 Oak St" }
            );

            // Accounts
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountId = 1, UserId = 1, DateOfCreation = DateTime.UtcNow, Type = "Savings", CurrentAmount = 5000.00 },
                new Account { AccountId = 2, UserId = 1, DateOfCreation = DateTime.UtcNow, Type = "Current", CurrentAmount = 25000.00 },
                new Account { AccountId = 3, UserId = 2, DateOfCreation = DateTime.UtcNow, Type = "Savings", CurrentAmount = 3000.00 },
                new Account { AccountId = 4, UserId = 3, DateOfCreation = DateTime.UtcNow, Type = "Current", CurrentAmount = 8000.00 }
            );

            // Cards
            modelBuilder.Entity<Card>().HasData(
                new Card { CardNumber = 1234567890123456, BankName = "A Bank", AccountId = 1, PIN = "1234", Expiry = DateTime.UtcNow.AddYears(3) },
                new Card { CardNumber = 2345678901234567, BankName = "B Bank", AccountId = 2, PIN = "5678", Expiry = DateTime.UtcNow.AddYears(2) },
                new Card { CardNumber = 3456789012345678, BankName = "A Bank", AccountId = 3, PIN = "9876", Expiry = DateTime.UtcNow.AddYears(3) }
            );

            // Transactions
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction {Id = 1,CardNumber = 1234567890123456, AtmId = 1, AccountId = 1, TransactionType = "Withdrawal", TransactionAmount = 50.00},
                new Transaction {Id=2,CardNumber = 1234567890123456, AtmId = 2, AccountId = 1, TransactionType = "Deposit", TransactionAmount = 100.00 },

                new Transaction {Id=3, CardNumber = 2345678901234567, AtmId = 1, AccountId = 2, TransactionType = "Withdrawal", TransactionAmount = 20.00 },
                new Transaction {Id=4,CardNumber = 2345678901234567, AtmId = 2, AccountId = 2, TransactionType = "Withdrawal", TransactionAmount = 10.00 },

                new Transaction {Id=5,CardNumber = 3456789012345678, AtmId = 1, AccountId = 3, TransactionType = "Deposit", TransactionAmount = 200.00 },
                new Transaction {Id=6,CardNumber = 3456789012345678, AtmId = 2, AccountId = 3, TransactionType = "Withdrawal", TransactionAmount = 50.00 }
            );

            modelBuilder.Entity<Atm>().HasData(
                new Atm { Id = 1, Location = "123 Park Ave", BankName = "A Bank" },
                new Atm { Id = 2, Location = "456 Elm St", BankName = "B Bank" }
            );
        }


    }

}
