using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTrainings = new HashSet<EmployeeTraining>();
            EmployeeWorkTimes = new HashSet<EmployeeWorkTime>();
            EventPlannings = new HashSet<EventPlanning>();
            Events = new HashSet<Event>();
        }

        public int EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string Email { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string? Middlename { get; set; }
        public string Password { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public Role Role { get; set; }
        public DateTime? PasswordReset { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool AcceptTerms { get; set; }
        public DateTime? BirthDate { get; set; }


        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public virtual Department? Department { get; set; }
        public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
        public virtual ICollection<EmployeeWorkTime> EmployeeWorkTimes { get; set; }
        public virtual ICollection<EventPlanning> EventPlannings { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public  List <RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x=>x.Token == token) != null;
        }
    }
}
