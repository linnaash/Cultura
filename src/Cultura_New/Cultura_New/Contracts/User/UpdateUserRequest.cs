namespace Cultura_New.Contracts.User
{
    public class UpdateUserRequest
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int? EmployeeId { get; set; }
    }
}
