using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            EmergencyPlans = new HashSet<EmergencyPlan>();
            EmployeeReports = new HashSet<EmployeeReport>();
            EmployeeSchedules = new HashSet<EmployeeSchedule>();
            EmployeeTasks = new HashSet<EmployeeTask>();
            EmployeeTrainings = new HashSet<EmployeeTraining>();
            EmployeeWorkTimes = new HashSet<EmployeeWorkTime>();
            EventPlannings = new HashSet<EventPlanning>();
            Events = new HashSet<Event>();
            Users = new HashSet<User>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<EmergencyPlan> EmergencyPlans { get; set; }
        public virtual ICollection<EmployeeReport> EmployeeReports { get; set; }
        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
        public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
        public virtual ICollection<EmployeeWorkTime> EmployeeWorkTimes { get; set; }
        public virtual ICollection<EventPlanning> EventPlannings { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}