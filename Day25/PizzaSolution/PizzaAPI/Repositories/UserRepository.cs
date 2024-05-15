using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaAPI.Context;
using PizzaAPI.Models;
using PizzaAPI.Repositories.Interfaces;

namespace PizzaAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaShopContext _context;

        public UserRepository(PizzaShopContext context)
        {
            _context = context;
        }

        async public Task<User> Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        async public Task<User> Delete(int key)
        {
            var user = await GetByKey(key);

            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync(true);
                return user;
            }

            throw new Exception($"User with id - {key} not found");
        }

        async public Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public Task<User> GetByKey(int key)
        {
            var user = _context.Users.FirstOrDefaultAsync(e => e.Id == key);

            if (user != null) return user;

            throw new Exception($"User with id - {key} not found");
        }

        async public Task<User> Update(User newUser)
        {
            var user = await GetByKey(newUser.Id);

            if (user != null)
            {
                _context.Update(newUser);
                await _context.SaveChangesAsync(true);
                return newUser;
            }

            throw new Exception($"User with id - {newUser.Id} not found");
        }
    }
}
