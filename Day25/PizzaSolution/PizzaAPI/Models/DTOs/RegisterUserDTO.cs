namespace PizzaAPI.Models.DTOs
{
    public class RegisterUserDTO : UserDTO
    {
        public string PlainTextPassword { get; set; } = string.Empty;
    }
}
