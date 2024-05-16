namespace PizzaAPI.Models.DTOs
{
    public class LoginUserDTO
    {
        public int Id { get; set; }
        public string PlainTextPassword { get; set; } = string.Empty;
    }
}
