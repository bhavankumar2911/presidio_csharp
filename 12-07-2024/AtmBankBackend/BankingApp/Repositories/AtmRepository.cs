using BankingApp.Models;
using BankingApp.Repositories.Interface;
using BankingApp.Exceptions;
using BankingApp.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Repositories
{
    public class AtmRepository : IRepository<int, Atm>
    {

        private readonly AtmContext _context;
        public AtmRepository(AtmContext context)
        {
            _context = context;
        }
        public async Task<Atm> Add(Atm item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Atm> DeleteByKey(int key)
        {
            var account = await GetByKey(key);
            if (account != null)
            {
                _context.Remove(account);
                await _context.SaveChangesAsync(true);
                return account;
            }
            throw new ElementNotFoundException("Atm");
        }

        public async Task<Atm> GetByKey(int key)
        {
            var account = await _context.Atms.FirstOrDefaultAsync(u => u.Id == key);

            if (account != null)
            {
                return account;
            }

            throw new ElementNotFoundException("Atm");
        }

        public async Task<IEnumerable<Atm>> GetAll()
        {
            var atms = await _context.Atms.ToListAsync();

            if (atms.Any())
            {
                return atms;
            }

            throw new EmptyListException("Atm");

        }

        public async Task<Atm> Update(Atm item)
        {
            var account = await GetByKey(item.Id);
            if (account != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return account;
            }
            throw new ElementNotFoundException("Atm");
        }

    }
}
