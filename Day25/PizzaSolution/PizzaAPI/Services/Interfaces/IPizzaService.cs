using PizzaAPI.Models;

namespace PizzaAPI.Services.Interfaces
{
    public interface IPizzaService
    {
        public Task<IList<Pizza>> GetAllPizzas();
    }
}
