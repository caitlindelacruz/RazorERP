using Microsoft.AspNetCore.Identity;
using RazorERP.Application.Interfaces;
using RazorERP.Domain.Entities;

namespace RazorERP.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public string HashPassword(string password)
        {
            var user = new User();
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var user = new User();
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
