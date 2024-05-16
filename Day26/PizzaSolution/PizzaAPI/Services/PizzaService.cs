using PizzaAPI.Models;
using PizzaAPI.Repositories.Interfaces;
using PizzaAPI.Services.Interfaces;
using System.Numerics;

namespace PizzaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        public async Task<IList<Pizza>> GetAllPizzas()
        {
            var allPizzas = await _repository.GetAll();
            return allPizzas.ToList();
        }
    }
}
