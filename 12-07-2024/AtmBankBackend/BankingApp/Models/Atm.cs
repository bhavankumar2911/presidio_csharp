using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models
{
    public class Atm
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public string BankName { get; set; }

        public List<Transaction> Transactions { get; set; }

    }
}
