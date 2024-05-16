namespace PizzaAPI.Models.DTOs
{
    public class LoginReturnDTO
    {
        public string Token { get; set; } = string.Empty;
        public UserDTO user { get; set; } = new UserDTO();
    }
}
