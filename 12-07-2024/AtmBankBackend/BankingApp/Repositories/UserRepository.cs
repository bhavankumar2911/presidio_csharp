using BankingApp.Models;
using BankingApp.Repositories.Interface;
using BankingApp.Exceptions;
using BankingApp.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Repositories
{
    public class UserRepository : IRepository<int, User>
    {

        private readonly AtmContext _context;
        public UserRepository(AtmContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> DeleteByKey(int key)
        {
            var user = await GetByKey(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync(true);
                return user;
            }
            throw new ElementNotFoundException("User");
        }

        public async Task<User> GetByKey(int key)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == key);

            if (user != null)
            {
                return user;
            }

            throw new ElementNotFoundException("User");
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            if (users.Any())
            {
                return users;
            }

            throw new EmptyListException("User");

        }

        public async Task<User> Update(User item)
        {
            var user = await GetByKey(item.Id);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync(true);
                return user;
            }
            throw new ElementNotFoundException("User");
        }

    }
}
