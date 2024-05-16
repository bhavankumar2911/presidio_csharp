using PizzaAPI.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Models
{
    public class User : UserDTO
    {
        public byte[] HashedPassword { get; set; } = new byte[0];

        public byte[] PasswordHashKey { get; set; } = new byte[0];
    }
}
