using System.Text.Json.Serialization;


namespace BusinessLogic.Models.Accounts
{
    public class AuthenticateResponse
    {
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // для того, чтобы вернуть токен в качестве куки
        public string RefreshToken { get; set; }
    }
}
