using RoleBasedAuthenticationAPI.Models;
using RoleBasedAuthenticationAPI.Models.DTOs;

namespace RoleBasedAuthenticationAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<LoginReturnDTO> LoginUser(LoginEmployeeDTO loginEmployeeDTO);

        public Task<EmployeeDTO> RegisterUser(RegisterEmployeeInputDTO registerEmployeeInputDTO);

        public Task<Employee> FindEmployeeByEmail(string email);

        public Task ActivateEmployee (int employeeId);  
    }
}
