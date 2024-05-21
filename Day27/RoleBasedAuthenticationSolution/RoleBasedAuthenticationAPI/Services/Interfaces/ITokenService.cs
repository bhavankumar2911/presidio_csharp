using RoleBasedAuthenticationAPI.Models.DTOs;

namespace RoleBasedAuthenticationAPI.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(EmployeeDTO employeeDTO);
    }
}
