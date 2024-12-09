using Domain.Entities;

namespace Domain.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;
        public string Middlename { get; set; } = null;
        public DateTime BirthDate { get;set; }
        public string Login { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password {  get; set; } = null!;
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

        public bool AcceptTerms { get; set; }
        public Role Role { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified {  get; set; }
        public bool ISVerified => Verified.HasValue || PasswordReset.HasValue;
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset {  get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x=> x.Token == token) != null;
        }

     }
}
