
using Domain.Entities;
using Domain.Models;

namespace BusinessLogic.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Employee account);
        public int? ValidateJwtToken(string token);
        public Task<RefreshToken> GenerateResreshToken(string ipAddress);
    }
}
