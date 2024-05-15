using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Exceptions;
using PizzaAPI.Models;
using PizzaAPI.Services.Interfaces;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Pizza>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IList<Pizza>>> GetAllPizzas()
        {
            try
            {
                var pizzas = await _pizzaService.GetAllPizzas();

                return Ok(pizzas);
            } catch (Exception ex)
            {
                return NotFound(new ErrorResponse(204, ex.Message));
            }
        }
    }
}
