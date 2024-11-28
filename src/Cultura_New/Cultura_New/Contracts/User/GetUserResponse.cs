using Domain.Models;

namespace Cultura_New.Contracts.User
{
    public class GetUserResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int? EmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
