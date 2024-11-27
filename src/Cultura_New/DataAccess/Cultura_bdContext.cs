using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace DataAccess
{
    public partial class Cultura_bdContext : DbContext
    {
        public Cultura_bdContext()
        {
        }

        public Cultura_bdContext(DbContextOptions<Cultura_bdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EmergencyPlan> EmergencyPlans { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventAttendance> EventAttendances { get; set; } = null!;
        public virtual DbSet<EventCategory> EventCategories { get; set; } = null!;
        public virtual DbSet<EventFinance> EventFinances { get; set; } = null!;
        public virtual DbSet<EventPlanning> EventPlannings { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Sponsor> Sponsors { get; set; } = null!;
        public virtual DbSet<StaffReport> StaffReports { get; set; } = null!;
        public virtual DbSet<StaffSchedule> StaffSchedules { get; set; } = null!;
        public virtual DbSet<StaffTask> StaffTasks { get; set; } = null!;
        public virtual DbSet<StaffTraining> StaffTrainings { get; set; } = null!;
        public virtual DbSet<StaffWorkTime> StaffWorkTimes { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Venue> Venues { get; set; } = null!;
        public virtual DbSet<Volunteer> Volunteers { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentHeadId).HasColumnName("DepartmentHeadID");

                entity.Property(e => e.DepartmentName).HasMaxLength(255);

                entity.HasOne(d => d.DepartmentHead)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.DepartmentHeadId)
                    .HasConstraintName("FK__Departmen__Depar__6383C8BA");
            });

            modelBuilder.Entity<EmergencyPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__Emergenc__755C22D7F2E147C9");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.EmergencyDescription).HasMaxLength(255);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ResponsibleStaffId).HasColumnName("ResponsibleStaffID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EmergencyPlans)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Emergency__Event__778AC167");

                entity.HasOne(d => d.ResponsibleStaff)
                    .WithMany(p => p.EmergencyPlans)
                    .HasForeignKey(d => d.ResponsibleStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Emergency__Respo__787EE5A0");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('Staff')");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__6477ECF3");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventCategoryId).HasColumnName("EventCategoryID");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.Property(e => e.ResponsibleStaffId).HasColumnName("ResponsibleStaffID");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.EventCategory)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__EventCat__656C112C");

                entity.HasOne(d => d.ResponsibleStaff)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ResponsibleStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__Responsi__6754599E");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__VenueID__66603565");
            });

            modelBuilder.Entity<EventAttendance>(entity =>
            {
                entity.HasKey(e => e.AttendanceId)
                    .HasName("PK__EventAtt__8B69263CC280A022");

                entity.ToTable("EventAttendance");

                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.AttendeeName).HasMaxLength(255);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventAttendances)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventAtte__Event__70DDC3D8");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.Property(e => e.EventCategoryId).HasColumnName("EventCategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<EventFinance>(entity =>
            {
                entity.HasKey(e => e.FinanceId)
                    .HasName("PK__EventFin__7917A8FF33592B85");

                entity.ToTable("EventFinance");

                entity.Property(e => e.FinanceId).HasColumnName("FinanceID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventFinances)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventFina__Event__74AE54BC");
            });

            modelBuilder.Entity<EventPlanning>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__EventPla__755C22D7125023CB");

                entity.ToTable("EventPlanning");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.PlanDescription).HasMaxLength(255);

                entity.Property(e => e.ResponsibleStaffId).HasColumnName("ResponsibleStaffID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventPlannings)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventPlan__Event__6B24EA82");

                entity.HasOne(d => d.ResponsibleStaff)
                    .WithMany(p => p.EventPlannings)
                    .HasForeignKey(d => d.ResponsibleStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventPlan__Respo__6C190EBB");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.AttendeeName).HasMaxLength(255);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.SubmissionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.Property(e => e.PartnerId).HasColumnName("PartnerID");

                entity.Property(e => e.ContactInfo).HasMaxLength(255);

                entity.Property(e => e.PartnerName).HasMaxLength(255);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.ResourceName).HasMaxLength(255);

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resources__Venue__6A30C649");
            });

            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.Property(e => e.SponsorId).HasColumnName("SponsorID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.SponsorName).HasMaxLength(255);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Sponsors)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sponsors__EventI__6E01572D");
            });

            modelBuilder.Entity<StaffReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__StaffRep__D5BD48E5EB9C22E2");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ReportDescription).HasMaxLength(255);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StaffReports)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StaffRepo__Emplo__6EF57B66");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StaffReports)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__StaffRepo__Event__6FE99F9F");
            });

            modelBuilder.Entity<StaffSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__StaffSch__9C8A5B69BE89F9F7");

                entity.ToTable("StaffSchedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ShiftEnd).HasColumnType("datetime");

                entity.Property(e => e.ShiftStart).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StaffSchedules)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StaffSche__Emplo__75A278F5");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.StaffSchedules)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StaffSche__Venue__76969D2E");
            });

            modelBuilder.Entity<StaffTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__StaffTas__7C6949D15911892C");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.AssignedStaffId).HasColumnName("AssignedStaffID");

                entity.Property(e => e.TaskDescription).HasMaxLength(255);

                entity.HasOne(d => d.AssignedStaff)
                    .WithMany(p => p.StaffTasks)
                    .HasForeignKey(d => d.AssignedStaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StaffTask__Assig__68487DD7");
            });

            modelBuilder.Entity<StaffTraining>(entity =>
            {
                entity.HasKey(e => e.TrainingId)
                    .HasName("PK__StaffTra__E8D71DE2C8F980D4");

                entity.ToTable("StaffTraining");

                entity.Property(e => e.TrainingId).HasColumnName("TrainingID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TrainingName).HasMaxLength(255);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StaffTrainings)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StaffTrai__Emplo__71D1E811");
            });

            modelBuilder.Entity<StaffWorkTime>(entity =>
            {
                entity.HasKey(e => e.WorkTimeId)
                    .HasName("PK__StaffWor__E4A9C6597ABC0A03");

                entity.ToTable("StaffWorkTime");

                entity.Property(e => e.WorkTimeId).HasColumnName("WorkTimeID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.StaffWorkTimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StaffWork__Emplo__72C60C4A");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StaffWorkTimes)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__StaffWork__Event__73BA3083");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.Property(e => e.SupplyId).HasColumnName("SupplyID");

                entity.Property(e => e.SupplyName).HasMaxLength(255);

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Supplies__VenueI__6D0D32F4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E45C3D8BD0")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Users__EmployeeI__4222D4EF");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.VenueName).HasMaxLength(255);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.VolunteerName).HasMaxLength(255);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Volunteer__Event__693CA210");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
