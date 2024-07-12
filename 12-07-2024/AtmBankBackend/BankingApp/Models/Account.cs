using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    public class Account
    {
        [Key]
        public long AccountId { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public User User { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string Type { get; set; }

        public double CurrentAmount { get; set; }

        public List<Transaction>? Transactions { get; set; }       


    }
}
