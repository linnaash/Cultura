using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
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

        public virtual DbSet<Analytic> Analytics { get; set; } = null!;
        public virtual DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; } = null!;
        public virtual DbSet<EmployeeWorkTime> EmployeeWorkTimes { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventAttendance> EventAttendances { get; set; } = null!;
        public virtual DbSet<EventCategory> EventCategories { get; set; } = null!;
        public virtual DbSet<EventFinance> EventFinances { get; set; } = null!;
        public virtual DbSet<EventPlanning> EventPlannings { get; set; } = null!;
        public virtual DbSet<EventTicket> EventTickets { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<MarketingCampaign> MarketingCampaigns { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Sponsor> Sponsors { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;
        public virtual DbSet<Venue> Venues { get; set; } = null!;
        public virtual DbSet<Volunteer> Volunteers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-E1QR638;Database=Cultura_bdNew;User Id=sa;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analytic>(entity =>
            {
                entity.HasKey(e => e.AnalyticsId)
                    .HasName("PK__Analytic__506974E33700B5A1");

                entity.ToTable("Analytic");

                entity.Property(e => e.CalculatedAt).HasColumnType("datetime");

                entity.Property(e => e.MetricName).HasMaxLength(255);

                entity.Property(e => e.MetricValue).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Analytics)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Analytics_Event");
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__AuditLog__5E548648248A1825");

                entity.ToTable("AuditLog");

                entity.Property(e => e.ModifiedBy).HasMaxLength(255);

                entity.Property(e => e.Operation).HasMaxLength(50);

                entity.Property(e => e.OperationTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TableName).HasMaxLength(255);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentName).HasMaxLength(255);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Email, "UQ__Employee__A9D105347C263F44")
                    .IsUnique();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Firstname).HasMaxLength(255);

                entity.Property(e => e.Lastname).HasMaxLength(255);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Middlename).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PasswordReset).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.ResetToken).HasMaxLength(255);

                entity.Property(e => e.ResetTokenExpires).HasColumnType("datetime");

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.VerificationToken).HasMaxLength(255);

                entity.Property(e => e.Verified).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Employee_Department");

                entity.Property(e => e.Role)
                    .HasConversion(v => v.ToString(), // Конвертация Enum в строку для базы данных
                     v => (Role)Enum.Parse(typeof(Role), v)) // Конвертация строки обратно в Enum
                    .HasMaxLength(50);
                /*.HasDefaultValue(Role.User);*/
            });

            modelBuilder.Entity<EmployeeTraining>(entity =>
            {
                entity.HasKey(e => e.TrainingId)
                    .HasName("PK__Employee__E8D71D82C696827E");

                entity.ToTable("EmployeeTraining");

                entity.Property(e => e.TrainingName).HasMaxLength(255);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTrainings)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeTraining_Employee");
            });

            modelBuilder.Entity<EmployeeWorkTime>(entity =>
            {
                entity.HasKey(e => e.WorkTimeId)
                    .HasName("PK__Employee__E4A9C6397EB9C3B0");

                entity.ToTable("EmployeeWorkTime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeWorkTimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeWorkTime_Employee");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EmployeeWorkTimes)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_EmployeeWorkTime_Event");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(255);

                entity.HasOne(d => d.EventCategory)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventCategoryId)
                    .HasConstraintName("FK_Event_EventCategory");

                entity.HasOne(d => d.ResponsibleEmployee)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ResponsibleEmployeeId)
                    .HasConstraintName("FK_Event_ResponsibleEmployee");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.VenueId)
                    .HasConstraintName("FK_Event_Venue");
            });

            modelBuilder.Entity<EventAttendance>(entity =>
            {
                entity.HasKey(e => e.AttendanceId)
                    .HasName("PK__EventAtt__8B69261C08F60E6C");

                entity.ToTable("EventAttendance");

                entity.Property(e => e.AttendeeName).HasMaxLength(255);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventAttendances)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAttendance_Event");
            });

            modelBuilder.Entity<EventCategory>(entity =>
            {
                entity.ToTable("EventCategory");

                entity.HasIndex(e => e.CategoryName, "UQ__EventCat__8517B2E03C345888")
                    .IsUnique();

                entity.Property(e => e.CategoryName).HasMaxLength(255);
            });

            modelBuilder.Entity<EventFinance>(entity =>
            {
                entity.HasKey(e => e.FinanceId)
                    .HasName("PK__EventFin__7917A89F9C973177");

                entity.ToTable("EventFinance");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventFinances)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventFinance_Event");
            });

            modelBuilder.Entity<EventPlanning>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__EventPla__755C22B7A9D1B463");

                entity.ToTable("EventPlanning");

                entity.Property(e => e.PlanDescription).HasMaxLength(255);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventPlannings)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventPlanning_Event");

                entity.HasOne(d => d.ResponsibleEmployee)
                    .WithMany(p => p.EventPlannings)
                    .HasForeignKey(d => d.ResponsibleEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventPlanning_ResponsibleEmployee");


            });

            modelBuilder.Entity<EventTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__EventTic__712CC607628B2B84");

                entity.ToTable("EventTicket");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventTickets)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_EventTicket_Event");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.AttendeeName).HasMaxLength(255);

                entity.Property(e => e.FeedbackText).HasMaxLength(255);

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Event");
            });

            modelBuilder.Entity<MarketingCampaign>(entity =>
            {
                entity.HasKey(e => e.CampaignId)
                    .HasName("PK__Marketin__3F5E8A990097C070");

                entity.ToTable("MarketingCampaign");

                entity.Property(e => e.CampaignName).HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedByIp).HasMaxLength(45);

                entity.Property(e => e.Expires).HasColumnType("datetime");

                entity.Property(e => e.ReasonRevoked).HasMaxLength(255);

                entity.Property(e => e.ReplacedByToken).HasMaxLength(512);

                entity.Property(e => e.Revoked).HasColumnType("datetime");

                entity.Property(e => e.RevokedByIp).HasMaxLength(45);

                entity.Property(e => e.Token).HasMaxLength(512);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefreshTokens_Employee");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource");

                entity.Property(e => e.ResourceName).HasMaxLength(255);

                entity.Property(e => e.ResourceType).HasMaxLength(50);
            });

            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.ToTable("Sponsor");

                entity.Property(e => e.SponsorName).HasMaxLength(255);
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("Supply");

                entity.Property(e => e.SupplyName).HasMaxLength(255);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Supply_Event");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("Venue");

                entity.Property(e => e.VenueLocation).HasMaxLength(255);

                entity.Property(e => e.VenueName).HasMaxLength(255);
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.ToTable("Volunteer");

                entity.Property(e => e.VolunteerName).HasMaxLength(255);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Volunteer_Event");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
