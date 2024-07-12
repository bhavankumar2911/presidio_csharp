namespace BankingApp.Models.DTO
{
    public class DepositDTO
    {
        public long CardNumber { get; set; }
        public string Pin { get; set; }
        public double Amount { get; set; }
        public int AtmId { get; set; }
    }
}
