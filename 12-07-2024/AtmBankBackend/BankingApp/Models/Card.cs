using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    public class Card
    {

        [Key]
        public long CardNumber { get; set; }

        public string BankName { get; set; }

        public long AccountId { get; set; }
        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }

        public string PIN { get; set; }

        public DateTime Expiry { get; set; }

        public List<Transaction>? TransactionList { get; set; }

    }
}
