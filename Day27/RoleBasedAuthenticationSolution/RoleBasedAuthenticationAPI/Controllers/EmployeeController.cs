using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Exceptions;
using RoleBasedAuthenticationAPI.Models.DTOs;
using RoleBasedAuthenticationAPI.Services.Interfaces;

namespace RoleBasedAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("/Register")]
        [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<EmployeeDTO>> Register(RegisterEmployeeInputDTO registerEmployeeInputDTO)
        {
            try
            {
                EmployeeDTO employeeDTO = await _employeeService.RegisterUser(registerEmployeeInputDTO);

                return Ok(employeeDTO);
            }
            catch (Exception ex)
            {
                return Conflict(new ErrorResponse(409, ex.Message));
            }
        }

        [HttpPost("/Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(LoginEmployeeDTO loginEmployeeDTO)
        {
            try
            {
                LoginReturnDTO loginReturnDTO = await _employeeService.LoginUser(loginEmployeeDTO);

                return Ok(loginReturnDTO);
            }
            catch (Exception ex)
            {
                if (ex.Message == $"{loginEmployeeDTO.Email} is not registered.")
                    return NotFound(new ErrorResponse(404, ex.Message));
                
                return Unauthorized(new ErrorResponse(401, ex.Message));
            }
        }

        [HttpPut("/ActivateEmployee")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> ActivateEmployee(int employeeId)
        {
            try
            {
                await _employeeService.ActivateEmployee(employeeId);
                Console.WriteLine("running");
                return Ok($"Employee with id {employeeId} is active now.");
            } catch (Exception ex)
            {
                return NotFound(new ErrorResponse(404, ex.Message));
            }
        }
    }
}
