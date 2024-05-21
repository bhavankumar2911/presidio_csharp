using RoleBasedAuthenticationAPI.Models;
using RoleBasedAuthenticationAPI.Models.DTOs;
using RoleBasedAuthenticationAPI.Repository.Interfaces;
using RoleBasedAuthenticationAPI.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace RoleBasedAuthenticationAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _repository;
        private readonly ITokenService _tokenService;

        public EmployeeService(IRepository<int, Employee> repository, ITokenService tokenService)
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

        private LoginReturnDTO ConvertEmployeeToLoginReturnDTO(Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Role = employee.Role,
                IsActive = employee.IsActive,
            };

            LoginReturnDTO loginReturnDTO = new LoginReturnDTO()
            {
                employee = employeeDTO,
                Token = _tokenService.GenerateToken(employeeDTO)
            };

            return loginReturnDTO;
        }

        public async Task<Employee> FindEmployeeByEmail(string email)
        {
            var employees = await _repository.GetAll();

            foreach (var employee in employees)
            {
                if (employee.Email == email) return employee;
            }

            throw new Exception($"{email} is not registered.");
        }

        public async Task<LoginReturnDTO> LoginUser(LoginEmployeeDTO loginEmployeeDTO)
        {
            Employee employee = await FindEmployeeByEmail(loginEmployeeDTO.Email);

            // check password
            HMACSHA512 hMACSHA512 = new HMACSHA512(employee.PasswordHashKey);
            byte[] hashedPassword = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(loginEmployeeDTO.PlainTextPassword));

            if (ComparePassword(hashedPassword, employee.HashedPassword))
            {
                if (!employee.IsActive) throw new Exception("You are unauthorized");
                return ConvertEmployeeToLoginReturnDTO(employee);
            }

            throw new Exception("Invalid credentials");
        }

        private byte[] GetHashKey(HMACSHA512 hMACSHA)
        {
            return hMACSHA.Key;
        }

        private byte[] GetHashedPassword(HMACSHA512 hMACSHA, string plainTextPassword)
        {
            return hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
        }

        private Employee PrepareEmployeeForRegister(RegisterEmployeeDTO registerEmployeeDTO, byte[] passwordHashKey, byte[] hashedPassword)
        {
            Employee employee = new Employee()
            {
                Name = registerEmployeeDTO.Name,
                Email = registerEmployeeDTO.Email,
                Age = registerEmployeeDTO.Age,
                Role = registerEmployeeDTO.Role,
                IsActive = false,
                PasswordHashKey = passwordHashKey,
                HashedPassword = hashedPassword
            };

            return employee;
        }

        public async Task<EmployeeDTO> RegisterUser(RegisterEmployeeInputDTO registerEmployeeInputDTO)
        {
            var employees = await _repository.GetAll();

            // check user with same email
            foreach (var employee in employees)
            {
                if (employee.Email == registerEmployeeInputDTO.Email)
                {
                    throw new Exception("Email address already in use");
                }
            }

            // create password hash key
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            byte[] key = GetHashKey(hMACSHA512);

            // compute hashed password
            byte[] hashedPassword = GetHashedPassword(hMACSHA512, registerEmployeeInputDTO.PlainTextPassword);

            // map user
            Employee newEmployee = PrepareEmployeeForRegister(registerEmployeeInputDTO, key, hashedPassword);

            return ConvertEmployeeToEmployeeDTO(await _repository.Add(newEmployee));
        }

        public EmployeeDTO ConvertEmployeeToEmployeeDTO (Employee employee)
        {
            return new EmployeeDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Age = employee.Age,
                Role = employee.Role,
                IsActive = employee.IsActive,
            };
        }

        public async Task ActivateEmployee(int employeeId)
        {
            Employee employee = await _repository.GetByKey(employeeId);
            employee.IsActive = true;
            await _repository.Update(employee);
        }
    }
}
