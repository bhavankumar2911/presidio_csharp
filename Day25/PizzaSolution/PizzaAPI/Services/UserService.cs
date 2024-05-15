using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaAPI.Models;
using PizzaAPI.Models.DTOs;
using PizzaAPI.Repositories.Interfaces;
using PizzaAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PizzaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _repository;

        public UserService(IRepository<int, User> repository)
        {
            _repository = repository;
        }

        public Task<UserDTO> LoginUser(int userId, string password)
        {
            throw new NotImplementedException();
        }

        private byte[] GetHashKey (HMACSHA512 hMACSHA)
        {
            return hMACSHA.Key;
        }

        private byte[] GetHashedPassword(HMACSHA512 hMACSHA, string plainTextPassword)
        {
            return hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
        }

        private User PrepareUserForRegister(RegisterUserDTO registerUserDTO, byte[] passwordHashKey, byte[] hashedPassword)
        {
            User user = new User()
            {
                Name = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                Phone = registerUserDTO.Phone,
                Address = registerUserDTO.Address,
                PasswordHashKey = passwordHashKey,
                HashedPassword = hashedPassword
            };

            return user;
        }

        public async Task<UserDTO> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var users = await _repository.GetAll();

            // check user with same email
            foreach (var eachUser in users)
            {
                if (eachUser.Email == registerUserDTO.Email)
                {
                    throw new Exception("Email address already in use");
                }
            }

            // create password hash key
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            byte[] key = GetHashKey(hMACSHA512);

            // compute hashed password
            byte[] hashedPassword = GetHashedPassword(hMACSHA512, registerUserDTO.PlainTextPassword);

            // map user
            User newUser = PrepareUserForRegister(registerUserDTO, key, hashedPassword);

            var registeredUser = await _repository.Add(newUser);

            return registeredUser;
        }
    }
}
