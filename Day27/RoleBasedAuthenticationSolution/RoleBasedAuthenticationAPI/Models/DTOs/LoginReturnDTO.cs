namespace RoleBasedAuthenticationAPI.Models.DTOs
{
    public class LoginReturnDTO
    {
        public string Token { get; set; } = string.Empty;

        public EmployeeDTO employee { get; set; } = new EmployeeDTO();
    }
}
