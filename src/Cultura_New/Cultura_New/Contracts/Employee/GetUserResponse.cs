using Domain.Models;

namespace Cultura_New.Contracts.Employee;

public class GetEmployeeResponse
{
    public int EmployeeId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Middlename { get; set; } = null!;
    public DateTime Birthdate { get; set; }

    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

}
