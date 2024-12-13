using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Models;
using Domain.Entities;

namespace DataAccess.Models
{
    public partial class Cultura_bdNewContext : DbContext
    {
        public Cultura_bdNewContext()
        {
        }

        public Cultura_bdNewContext(DbContextOptions<Cultura_bdNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<EmergencyPlan> EmergencyPlans { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeReport> EmployeeReports { get; set; } = null!;
        public virtual DbSet<EmployeeSchedule> EmployeeSchedules { get; set; } = null!;
        public virtual DbSet<EmployeeTask> EmployeeTasks { get; set; } = null!;
        public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; } = null!;
        public virtual DbSet<EmployeeWorkTime> EmployeeWorkTimes { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventAttendance> EventAttendances { get; set; } = null!;
        public virtual DbSet<EventCategory> EventCategories { get; set; } = null!;
        public virtual DbSet<EventFinance> EventFinances { get; set; } = null!;
        public virtual DbSet<EventPlanning> EventPlannings { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;

        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Sponsor> Sponsors { get; set; } = null!;
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
                    .HasConstraintName("FK__Departmen__Depar__693CA210");
            });

            modelBuilder.Entity<EmergencyPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__Emergenc__755C22D7C5F3287C");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.EmergencyDescription).HasMaxLength(255);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ResponsibleEmployeeId).HasColumnName("ResponsibleEmployeeID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EmergencyPlans)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Emergency__Event__7F2BE32F");

                entity.HasOne(d => d.ResponsibleEmployee)
                    .WithMany(p => p.EmergencyPlans)
                    .HasForeignKey(d => d.ResponsibleEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Emergency__Respo__00200768");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employees__Depar__6A30C649");
            });

            modelBuilder.Entity<EmployeeReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__Employee__D5BD48E52CFF8A29");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.ReportDescription).HasMaxLength(255);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeReports)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeR__Emplo__74AE54BC");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EmployeeReports)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EmployeeR__Event__75A278F5");
            });

            modelBuilder.Entity<EmployeeSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId)
                    .HasName("PK__Employee__9C8A5B690EC8C618");

                entity.ToTable("EmployeeSchedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ShiftEnd).HasColumnType("datetime");

                entity.Property(e => e.ShiftStart).HasColumnType("datetime");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSchedules)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Emplo__7D439ABD");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.EmployeeSchedules)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__Venue__7E37BEF6");
            });

            modelBuilder.Entity<EmployeeTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__Employee__7C6949D1675A77B9");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.AssignedEmployeeId).HasColumnName("AssignedEmployeeID");

                entity.Property(e => e.TaskDescription).HasMaxLength(255);

                entity.HasOne(d => d.AssignedEmployee)
                    .WithMany(p => p.EmployeeTasks)
                    .HasForeignKey(d => d.AssignedEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeT__Assig__6E01572D");
            });

            modelBuilder.Entity<EmployeeTraining>(entity =>
            {
                entity.HasKey(e => e.TrainingId)
                    .HasName("PK__Employee__E8D71DE2F66A8764");

                entity.ToTable("EmployeeTraining");

                entity.Property(e => e.TrainingId).HasColumnName("TrainingID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TrainingName).HasMaxLength(255);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTrainings)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeT__Emplo__778AC167");
            });

            modelBuilder.Entity<EmployeeWorkTime>(entity =>
            {
                entity.HasKey(e => e.WorkTimeId)
                    .HasName("PK__Employee__E4A9C65913DD95B0");

                entity.ToTable("EmployeeWorkTime");

                entity.Property(e => e.WorkTimeId).HasColumnName("WorkTimeID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeWorkTimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeW__Emplo__787EE5A0");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EmployeeWorkTimes)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__EmployeeW__Event__797309D9");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventCategoryId).HasColumnName("EventCategoryID");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.Property(e => e.ResponsibleEmployeeId).HasColumnName("ResponsibleEmployeeID");

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.EventCategory)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__EventCat__6B24EA82");

                entity.HasOne(d => d.ResponsibleEmployee)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ResponsibleEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__Responsi__6D0D32F4");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__VenueID__6C190EBB");
            });

            modelBuilder.Entity<EventAttendance>(entity =>
            {
                entity.HasKey(e => e.AttendanceId)
                    .HasName("PK__EventAtt__8B69263C02884FDD");

                entity.ToTable("EventAttendance");

                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.AttendeeName).HasMaxLength(255);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventAttendances)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventAtte__Event__76969D2E");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.Property(e => e.EventCategoryId).HasColumnName("EventCategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<EventFinance>(entity =>
            {
                entity.HasKey(e => e.FinanceId)
                    .HasName("PK__EventFin__7917A8FFC02201F2");

                entity.ToTable("EventFinance");

                entity.Property(e => e.FinanceId).HasColumnName("FinanceID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventFinances)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventFina__Event__7A672E12");
            });

            modelBuilder.Entity<EventPlanning>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__EventPla__755C22D75FAB2C5B");

                entity.ToTable("EventPlanning");

                entity.Property(e => e.PlanId).HasColumnName("PlanID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.PlanDescription).HasMaxLength(255);

                entity.Property(e => e.ResponsibleEmployeeId).HasColumnName("ResponsibleEmployeeID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventPlannings)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventPlan__Event__70DDC3D8");

                entity.HasOne(d => d.ResponsibleEmployee)
                    .WithMany(p => p.EventPlannings)
                    .HasForeignKey(d => d.ResponsibleEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EventPlan__Respo__71D1E811");
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

         

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.ResourceName).HasMaxLength(255);

                entity.Property(e => e.VenueId).HasColumnName("VenueID");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resources__Venue__6FE99F9F");
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
                    .HasConstraintName("FK__Sponsors__EventI__73BA3083");
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
                    .HasConstraintName("FK__Supplies__VenueI__72C60C4A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login, "UQ__Users__5E55825B88EF876B")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D1053423CE82B4")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Firstname).HasMaxLength(255);

                
                entity.Property(e => e.Lastname).HasMaxLength(255);

                entity.Property(e => e.Login).HasMaxLength(255);

                entity.Property(e => e.Middlename).HasMaxLength(255);

                entity.Property(e => e.PasswordReset).HasColumnType("datetime");

                entity.Property(e => e.ResetToken).HasMaxLength(255);

                entity.Property(e => e.ResetTokenExpires).HasColumnType("datetime");

                entity.Property(e => e.Role)
                    .HasConversion(v => v.ToString(), // Конвертация Enum в строку для базы данных
                     v => (Role)Enum.Parse(typeof(Role), v)) // Конвертация строки обратно в Enum
                    .HasMaxLength(50)
                    /*.HasDefaultValue(Role.User);*/ // Укажите значение по умолчанию из Enum


                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.VerificationToken).HasMaxLength(255);

                entity.Property(e => e.Verified).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Users__EmployeeI__68487DD7");
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
                    .HasConstraintName("FK__Volunteer__Event__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
