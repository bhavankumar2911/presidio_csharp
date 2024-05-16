using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaAPI.Context;
using PizzaAPI.Models;
using PizzaAPI.Repositories.Interfaces;

namespace PizzaAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaShopContext _context;

        public PizzaRepository(PizzaShopContext context)
        {
            _context = context;
        }

        async public Task<Pizza> Add(Pizza pizza)
        {
            _context.Add(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        async public Task<Pizza> Delete(int key)
        {
            var employee = await GetByKey(key);

            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync(true);
                return employee;
            }

            throw new Exception($"Pizza with id - {key} not found");
        }

        async public Task<IEnumerable<Pizza>> GetAll()
        {
            var pizzas = await _context.Pizzas.ToListAsync();
            if (pizzas.Count > 0) return pizzas;

            throw new Exception("No pizzas are available");
        }

        public Task<Pizza> GetByKey(int key)
        {
            var pizza = _context.Pizzas.FirstOrDefaultAsync(e => e.Id == key);

            if (pizza != null) return pizza;

            throw new Exception($"Pizza with id - {key} not found");
        }

        async public Task<Pizza> Update(Pizza newPizza)
        {
            var pizza = await GetByKey(newPizza.Id);

            if (pizza != null)
            {
                _context.Update(newPizza);
                await _context.SaveChangesAsync(true);
                return newPizza;
            }

            throw new Exception($"Pizza with id - {newPizza.Id} not found");
        }
    }
}
