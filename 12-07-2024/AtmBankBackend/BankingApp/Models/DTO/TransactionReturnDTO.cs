namespace BankingApp.Models.DTO
{
    public class TransactionReturnDTO
    {
        public string? AtmName { get; set; }
        public string? AtmLocation { get; set; }
        public int TransactionId { get; set; }
        public DateTime TransactionDateAndTime { get; set; }
        public string TransactionType { get; set; }
        public double TransactionAmount { get; set; }

        public TransactionReturnDTO(int transactionId, DateTime transactionDateAndTime, string transactionType, double transactionAmount)
        {
            TransactionId = transactionId;
            TransactionDateAndTime = transactionDateAndTime;
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
        }

        public TransactionReturnDTO(string atmName, string atmLocation, int transactionId, DateTime transactionDateAndTime, string transactionType, double transactionAmount)
        {
            AtmName = atmName;
            AtmLocation = atmLocation;
            TransactionId = transactionId;
            TransactionDateAndTime = transactionDateAndTime;
            TransactionType = transactionType;
            TransactionAmount = transactionAmount;
        }
    }
}
