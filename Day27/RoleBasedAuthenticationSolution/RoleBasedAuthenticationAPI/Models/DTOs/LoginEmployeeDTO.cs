namespace RoleBasedAuthenticationAPI.Models.DTOs
{
    public class LoginEmployeeDTO
    {
        public string Email { get; set; } = string.Empty;

        public string PlainTextPassword { get; set; } = string.Empty;
    }
}
