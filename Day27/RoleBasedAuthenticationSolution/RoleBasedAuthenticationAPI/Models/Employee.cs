using RoleBasedAuthenticationAPI.Models.DTOs;

namespace RoleBasedAuthenticationAPI.Models
{
    public class Employee : EmployeeDTO
    {
        public byte[] PasswordHashKey { get; set; } = new byte[0];

        public byte[] HashedPassword { get; set; } = new byte[0];
    }
}
