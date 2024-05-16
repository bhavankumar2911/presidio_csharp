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
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        private bool ComparePassword(byte[] passwordFromUser, byte[] passwordInDB)
        {
            if (passwordFromUser.Length != passwordInDB.Length) return false;

            for (int i = 0; i < passwordFromUser.Length; i++)
            {
                if (passwordFromUser[i] != passwordInDB[i])
                {
                    return false;
                }
            }
            return true;
        }

        private LoginReturnDTO ConvertUserToLoginReturnDTO(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
            };

            LoginReturnDTO loginReturnDTO = new LoginReturnDTO()
            {
                user = userDTO,
                Token = _tokenService.GenerateToken(userDTO)
            };

            return loginReturnDTO;
        }

        public async Task<LoginReturnDTO> LoginUser(LoginUserDTO loginUserDTO)
        {
            try
            {
                User user = await _repository.GetByKey(loginUserDTO.Id);

                // check password
                HMACSHA512 hMACSHA512 = new HMACSHA512(user.PasswordHashKey);
                byte[] hashedPassword = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(loginUserDTO.PlainTextPassword));

                if (ComparePassword(hashedPassword, user.HashedPassword))
                {
                    return ConvertUserToLoginReturnDTO(user);
                }

                throw new Exception("Invalid credentials");
            } catch (Exception ex)
            {
                if (ex.Message == $"User with id - {loginUserDTO.Id} not found")
                {
                    throw new Exception("Invalid credentials");
                }

                throw;
            }
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
