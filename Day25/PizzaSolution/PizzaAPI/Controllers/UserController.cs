using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Exceptions;
using PizzaAPI.Models.DTOs;
using PizzaAPI.Services.Interfaces;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/Register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserDTO>> Register (RegisterUserDTO registerUserDTO)
        {
            try
            {
                UserDTO userDTO = await _userService.RegisterUser(registerUserDTO);

                return Ok(userDTO);
            } catch (Exception ex)
            {
                return Conflict(new ErrorResponse(409, ex.Message));
            }
        }

        [HttpPost("/Login")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDTO>> Login(LoginUserDTO loginUserDTO)
        {
            try
            {
                UserDTO userDTO = await _userService.LoginUser(loginUserDTO);

                return Ok(userDTO);
            } catch (Exception ex)
            {
                return Unauthorized(new ErrorResponse(401, ex.Message));
            }
        }

    }
}
