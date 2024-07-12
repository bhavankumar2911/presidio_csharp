namespace BankingApp.Models.DTO
{
    public class BalanceReturnDTO
    {
        public string? AtmName { get; set; }
        public string? AtmLocation { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
        public long AccountId { get; set; }
        public string Type { get; set; }
        public double BalanceAmount { get; set; }

        public BalanceReturnDTO(string? atmName, string? atmLocation, long accountId, string type, double balanceAmount)
        {
            AtmName = atmName;
            AtmLocation = atmLocation;
            AccountId = accountId;
            Type = type;
            BalanceAmount = balanceAmount;
        }
    }
}
