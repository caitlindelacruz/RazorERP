using Microsoft.IdentityModel.Tokens;
using RazorERP.Application.Interfaces;
using RazorERP.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RazorERP.Infrastructure
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly string _secretKey;

        public JwtTokenGenerator(string secretKey)
        {
            _secretKey = secretKey;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
