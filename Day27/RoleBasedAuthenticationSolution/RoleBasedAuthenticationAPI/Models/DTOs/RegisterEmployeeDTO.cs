namespace RoleBasedAuthenticationAPI.Models.DTOs
{
    public class RegisterEmployeeDTO
    {
        public string Name { get; set; } = string.Empty;

        public double Age { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

    }
}
