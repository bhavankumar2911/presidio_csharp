using BankingApp.Models.DTO;

namespace BankingApp.Services.Interface
{
    public interface ITransactionService
    {
        public Task<string> Withdraw(WithdrawDTO dto);
        public Task<string> Deposit(DepositDTO depositDto);
        public Task<List<TransactionReturnDTO>> GetAllTransactions(CardReaderDTO dataReadDto);

        public Task<BalanceReturnDTO> GetBalance(CardReaderDTO cardReadDto);
    }
}
