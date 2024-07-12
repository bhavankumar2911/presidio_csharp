using BankingApp.Models;
using BankingApp.Repositories.Interface;
using BankingApp.Exceptions;
using BankingApp.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Repositories
{
    public class AccountRepository : IRepository<long, Account>
    {

        private readonly AtmContext _context;
        public AccountRepository(AtmContext context)
        {
            _context = context;
        }
        public async Task<Account> Add(Account item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Account> DeleteByKey(long key)
        {
            var account = await GetByKey(key);
            if (account != null)
            {
                _context.Remove(account);
                await _context.SaveChangesAsync(true);
                return account;
            }
            throw new ElementNotFoundException("Account");
        }

        public async Task<Account> GetByKey(long key)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(u => u.AccountId == key);

            if (account != null)
            {
                return account;
            }

            throw new ElementNotFoundException("Account");
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            var accounts = await _context.Accounts.ToListAsync();

            if (accounts.Any())
            {
                return accounts;
            }

            throw new EmptyListException("Account");

        }

        public async Task<Account> Update(Account item)
        {
            var account = await GetByKey(item.AccountId);
            if (account != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return account;
            }
            throw new ElementNotFoundException("Account");
        }

    }
}
