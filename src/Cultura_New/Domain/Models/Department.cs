using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public int? DepartmentHeadId { get; set; }

        public virtual Employee? DepartmentHead { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}