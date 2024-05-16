using PizzaAPI.Models.DTOs;

namespace PizzaAPI.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(UserDTO userDTO);
    }
}
