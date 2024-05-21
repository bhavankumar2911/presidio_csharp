namespace RoleBasedAuthenticationAPI.Models.DTOs
{
    public class RegisterEmployeeInputDTO : RegisterEmployeeDTO
    {
        public string PlainTextPassword { get; set; } = string.Empty;
    }
}
