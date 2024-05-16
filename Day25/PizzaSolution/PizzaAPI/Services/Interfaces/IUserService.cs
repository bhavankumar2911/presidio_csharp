using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;

namespace PizzaAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDTO> LoginUser(LoginUserDTO loginUserDTO);

        public Task<UserDTO> RegisterUser(RegisterUserDTO registerUserDTO);
    }
}
