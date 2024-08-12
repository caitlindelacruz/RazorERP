using RazorERP.Domain.Entities;

namespace RazorERP.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
