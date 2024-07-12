using BankingApp.Contexts;
using BankingApp.Exceptions;
using BankingApp.Models;
using BankingApp.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Repositories
{
    public class TransactionRepository : IRepository<int, Transaction>
    {

        private readonly AtmContext _context;
        public TransactionRepository(AtmContext context)
        {
            _context = context;
        }
        public async Task<Transaction> Add(Transaction item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Transaction> DeleteByKey(int key)
        {
            var transaction = await GetByKey(key);
            if (transaction != null)
            {
                _context.Remove(transaction);
                await _context.SaveChangesAsync(true);
                return transaction;
            }
            throw new ElementNotFoundException("Transaction");
        }

        public async Task<Transaction> GetByKey(int key)
        {
            var transaction = await _context.Transactions.Include(t=>t.Atm).Include(t=>t.Account).FirstOrDefaultAsync(u => u.Id == key);

            if (transaction != null)
            {
                return transaction;
            }

            throw new ElementNotFoundException("Transaction");
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            var transactions = await _context.Transactions.Include(t => t.Atm).Include(t => t.Account).ToListAsync();

            if (transactions.Any())
            {
                return transactions;
            }

            throw new EmptyListException("Transaction");

        }

        public async Task<Transaction> Update(Transaction item)
        {
            var transaction = await GetByKey(item.Id);
            if (transaction != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return transaction;
            }
            throw new ElementNotFoundException("Transaction");
        }

    }
}
