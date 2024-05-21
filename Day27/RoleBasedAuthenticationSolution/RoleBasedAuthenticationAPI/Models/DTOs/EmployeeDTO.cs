namespace RoleBasedAuthenticationAPI.Models.DTOs
{
    public class EmployeeDTO : RegisterEmployeeDTO
    {
        public int Id { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
