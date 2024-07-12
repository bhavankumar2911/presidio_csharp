using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingApp.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public long CardNumber { get; set; }
        public Card? Card { get; set; }
        public int? AtmId { get; set; }
        public Atm Atm { get; set; }
        public long AccountId { get; set; }
        public Account Account { get; set; }

        public string TransactionType { get; set; }

        public double TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public Transaction()
        {

        }

        public Transaction(long cardNumber, int? atmId, long accountId, string transactionType, double transactionAmount)
        {
            CardNumber = cardNumber;
            AtmId = atmId;
            AccountId = accountId;
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
        }
    }
}
