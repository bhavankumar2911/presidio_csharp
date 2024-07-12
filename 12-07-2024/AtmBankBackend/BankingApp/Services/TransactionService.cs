using BankingApp.Exceptions;
using BankingApp.Models;
using BankingApp.Models.DTO;
using BankingApp.Repositories.Interface;
using BankingApp.Services.Interface;

namespace BankingApp.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly IRepository<long, Card> _cardRepository;
        private readonly IRepository<long, Account> _accountRepository;
        private readonly IRepository<int, Transaction> _transactionRepository;
        private readonly IRepository<int, Atm> _atmRepository;

        public TransactionService(IRepository<int, Atm> atmRepository, IRepository<long, Card> cardRepository, IRepository<long, Account> accountRepository, IRepository<int, Transaction> transactionRepository)
        {

            _cardRepository = cardRepository;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _atmRepository = atmRepository;

        }

        public async Task<string> Deposit(DepositDTO depositDto)
        {
            Card card = await _cardRepository.GetByKey(depositDto.CardNumber);
            if (card == null || DateTime.Now > card.Expiry)
            {
                throw new InvalidCardException();
            }
            if (card.PIN != depositDto.Pin)
            {
                throw new UnauthorizedUserException("Invalid PIN");
            }

            Account account = await _accountRepository.GetByKey(card.AccountId);
            if (depositDto.Amount > 20000)
            {
                throw new LimitExceededException("You can only deposit Rs.20000 in a single transaction!");
            }
            account.CurrentAmount += depositDto.Amount;
            await _transactionRepository.Add(new Transaction(depositDto.CardNumber, depositDto.AtmId, account.AccountId, "deposit", depositDto.Amount));
            await _accountRepository.Update(account);
            return $"An amount of Rs.{depositDto.Amount} is credited to your account!";
        }

        public async Task<string> Withdraw(WithdrawDTO dto)
        {

            Card card = await _cardRepository.GetByKey(dto.CardNumber);

            if (card == null && DateTime.Now > card.Expiry)
            {
                throw new InvalidCardException();
            }
            if (card.PIN != dto.PIN)
            {
                throw new UnauthorizedUserException("Invalid PIN");
            }

            Account account = await _accountRepository.GetByKey(card.AccountId);



            if (account.CurrentAmount < dto.Amount)
            {
                throw new InsufficientFundsException("You have less amount in your account than withdraw request");
            }

            if (dto.Amount>10000)
            {
                throw new LimitExceededException("You can only withdraw Rs.10000 in a single transaction!");
            }

            account.CurrentAmount -= dto.Amount;
            await _transactionRepository.Add(new Transaction(dto.CardNumber,dto.AtmId,account.AccountId,"withdraw",dto.Amount));
            await _accountRepository.Update(account);

            return $"An amount of Rs.{dto.Amount} is debited from your account!";

        }

        public async Task<List<TransactionReturnDTO>> GetAllTransactions(CardReaderDTO dataReadDto)
        {
            Card card = await _cardRepository.GetByKey(dataReadDto.CardNumber);
            if (card == null || DateTime.Now > card.Expiry)
            {
                throw new InvalidCardException();
            }
            if (card.PIN != dataReadDto.Pin)
            {
                throw new UnauthorizedUserException("Invalid PIN");
            }
            var transactions = _transactionRepository.GetAll().Result.Where(t => t.CardNumber == dataReadDto.CardNumber);
            var transactionsList = new List<TransactionReturnDTO>();
            foreach (var transaction in transactions)
            {
                if (transaction.AtmId == null)
                {
                    transactionsList.Add(new TransactionReturnDTO(transaction.Id, transaction.TransactionDate, transaction.TransactionType, transaction.TransactionAmount));
                }
                transactionsList.Add(new TransactionReturnDTO(transaction.Atm.BankName, transaction.Atm.Location, transaction.Id, transaction.TransactionDate, transaction.TransactionType, transaction.TransactionAmount));
            }
            if (transactionsList.Count > 0)
                return transactionsList;
            throw new EmptyListException("No Transactions are done yet!");
        }

        public async Task<BalanceReturnDTO> GetBalance(CardReaderDTO cardReadDto)
        {
            try
            {
                Card card = await _cardRepository.GetByKey(cardReadDto.CardNumber);
                if (card == null || DateTime.Now > card.Expiry)
                {
                    throw new InvalidCardException();
                }
                if (card.PIN != cardReadDto.Pin)
                {
                    throw new UnauthorizedUserException("Invalid PIN");
                }
                var atm = await _atmRepository.GetByKey(cardReadDto.AtmId);
                return new BalanceReturnDTO(atm.BankName, atm.Location, card.AccountId, card.Account.Type, card.Account.CurrentAmount);

            }
            catch (ElementNotFoundException e)
            {
                throw;
            }

        }
    }
}
