using Microsoft.IdentityModel.Tokens;
using RoleBasedAuthenticationAPI.Models.DTOs;
using RoleBasedAuthenticationAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAuthenticationAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }
        public string GenerateToken(EmployeeDTO employeeDTO)
        {

            var claims = new List<Claim>(){
                new Claim("employee_id", employeeDTO.Id.ToString()),
                new Claim(ClaimTypes.Role, employeeDTO.Role)
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
