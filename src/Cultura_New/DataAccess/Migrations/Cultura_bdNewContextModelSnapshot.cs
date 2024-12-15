﻿// <auto-generated />
using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Cultura_bdNewContext))]
    partial class Cultura_bdNewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReasonRevoked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountUserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Domain.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<int?>("DepartmentHeadId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentHeadID");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("DepartmentHeadId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Models.EmergencyPlan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlanID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<string>("EmergencyDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<int>("ResponsibleEmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("ResponsibleEmployeeID");

                    b.HasKey("PlanId")
                        .HasName("PK__Emergenc__755C22D7C5F3287C");

                    b.HasIndex("EventId");

                    b.HasIndex("ResponsibleEmployeeId");

                    b.ToTable("EmergencyPlans");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Models.EmployeeReport", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ReportID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<string>("ReportDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ReportId")
                        .HasName("PK__Employee__D5BD48E52CFF8A29");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EventId");

                    b.ToTable("EmployeeReports");
                });

            modelBuilder.Entity("Domain.Models.EmployeeSchedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ScheduleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("ShiftEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ShiftStart")
                        .HasColumnType("datetime");

                    b.Property<int>("VenueId")
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    b.HasKey("ScheduleId")
                        .HasName("PK__Employee__9C8A5B690EC8C618");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VenueId");

                    b.ToTable("EmployeeSchedule", (string)null);
                });

            modelBuilder.Entity("Domain.Models.EmployeeTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<int>("AssignedEmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("AssignedEmployeeID");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TaskId")
                        .HasName("PK__Employee__7C6949D1675A77B9");

                    b.HasIndex("AssignedEmployeeId");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("Domain.Models.EmployeeTraining", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TrainingID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("TrainingName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TrainingId")
                        .HasName("PK__Employee__E8D71DE2F66A8764");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeTraining", (string)null);
                });

            modelBuilder.Entity("Domain.Models.EmployeeWorkTime", b =>
                {
                    b.Property<int>("WorkTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("WorkTimeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkTimeId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("WorkTimeId")
                        .HasName("PK__Employee__E4A9C65913DD95B0");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EventId");

                    b.ToTable("EmployeeWorkTime", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"), 1L, 1);

                    b.Property<int>("EventCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("EventCategoryID");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("date");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ResponsibleEmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("ResponsibleEmployeeID");

                    b.Property<int>("VenueId")
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    b.HasKey("EventId");

                    b.HasIndex("EventCategoryId");

                    b.HasIndex("ResponsibleEmployeeId");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.Models.EventAttendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AttendanceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceId"), 1L, 1);

                    b.Property<string>("AttendeeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.HasKey("AttendanceId")
                        .HasName("PK__EventAtt__8B69263C02884FDD");

                    b.HasIndex("EventId");

                    b.ToTable("EventAttendance", (string)null);
                });

            modelBuilder.Entity("Domain.Models.EventCategory", b =>
                {
                    b.Property<int>("EventCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EventCategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventCategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EventCategoryId");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("Domain.Models.EventFinance", b =>
                {
                    b.Property<int>("FinanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FinanceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FinanceId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.HasKey("FinanceId")
                        .HasName("PK__EventFin__7917A8FFC02201F2");

                    b.HasIndex("EventId");

                    b.ToTable("EventFinance", (string)null);
                });

            modelBuilder.Entity("Domain.Models.EventPlanning", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlanID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<string>("PlanDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ResponsibleEmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("ResponsibleEmployeeID");

                    b.HasKey("PlanId")
                        .HasName("PK__EventPla__755C22D75FAB2C5B");

                    b.HasIndex("EventId");

                    b.HasIndex("ResponsibleEmployeeId");

                    b.ToTable("EventPlanning", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FeedbackID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<string>("AttendeeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<string>("FeedbackText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmissionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ResourceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResourceId"), 1L, 1);

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("VenueId")
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    b.HasKey("ResourceId");

                    b.HasIndex("VenueId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Domain.Models.Sponsor", b =>
                {
                    b.Property<int>("SponsorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SponsorID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SponsorId"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<string>("SponsorName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SponsorId");

                    b.HasIndex("EventId");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Domain.Models.Supply", b =>
                {
                    b.Property<int>("SupplyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SupplyID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplyId"), 1L, 1);

                    b.Property<string>("SupplyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("VenueId")
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    b.HasKey("SupplyId");

                    b.HasIndex("VenueId");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Middlename")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime");

                    b.Property<string>("ResetToken")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.Property<string>("VerificationToken")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime");

                    b.HasKey("UserId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex(new[] { "Login" }, "UQ__Users__5E55825B88EF876B")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D1053423CE82B4")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VenueId"), 1L, 1);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VenueId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("Domain.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VolunteerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VolunteerId"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<string>("VolunteerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VolunteerId");

                    b.HasIndex("EventId");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Models.User", "Account")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("AccountUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Models.Department", b =>
                {
                    b.HasOne("Domain.Models.Employee", "DepartmentHead")
                        .WithMany("Departments")
                        .HasForeignKey("DepartmentHeadId")
                        .HasConstraintName("FK__Departmen__Depar__693CA210");

                    b.Navigation("DepartmentHead");
                });

            modelBuilder.Entity("Domain.Models.EmergencyPlan", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EmergencyPlans")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Emergency__Event__7F2BE32F");

                    b.HasOne("Domain.Models.Employee", "ResponsibleEmployee")
                        .WithMany("EmergencyPlans")
                        .HasForeignKey("ResponsibleEmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__Emergency__Respo__00200768");

                    b.Navigation("Event");

                    b.Navigation("ResponsibleEmployee");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.HasOne("Domain.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Employees__Depar__6A30C649");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Domain.Models.EmployeeReport", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeReports")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeR__Emplo__74AE54BC");

                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EmployeeReports")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__EmployeeR__Event__75A278F5");

                    b.Navigation("Employee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.EmployeeSchedule", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeSchedules")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeS__Emplo__7D439ABD");

                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("EmployeeSchedules")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeS__Venue__7E37BEF6");

                    b.Navigation("Employee");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.EmployeeTask", b =>
                {
                    b.HasOne("Domain.Models.Employee", "AssignedEmployee")
                        .WithMany("EmployeeTasks")
                        .HasForeignKey("AssignedEmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeT__Assig__6E01572D");

                    b.Navigation("AssignedEmployee");
                });

            modelBuilder.Entity("Domain.Models.EmployeeTraining", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeTrainings")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeT__Emplo__778AC167");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.EmployeeWorkTime", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("EmployeeWorkTimes")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__EmployeeW__Emplo__787EE5A0");

                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EmployeeWorkTimes")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__EmployeeW__Event__797309D9");

                    b.Navigation("Employee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.Event", b =>
                {
                    b.HasOne("Domain.Models.EventCategory", "EventCategory")
                        .WithMany("Events")
                        .HasForeignKey("EventCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__EventCat__6B24EA82");

                    b.HasOne("Domain.Models.Employee", "ResponsibleEmployee")
                        .WithMany("Events")
                        .HasForeignKey("ResponsibleEmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__Responsi__6D0D32F4");

                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__VenueID__6C190EBB");

                    b.Navigation("EventCategory");

                    b.Navigation("ResponsibleEmployee");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.EventAttendance", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EventAttendances")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventAtte__Event__76969D2E");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.EventFinance", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EventFinances")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventFina__Event__7A672E12");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.EventPlanning", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EventPlannings")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventPlan__Event__70DDC3D8");

                    b.HasOne("Domain.Models.Employee", "ResponsibleEmployee")
                        .WithMany("EventPlannings")
                        .HasForeignKey("ResponsibleEmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__EventPlan__Respo__71D1E811");

                    b.Navigation("Event");

                    b.Navigation("ResponsibleEmployee");
                });

            modelBuilder.Entity("Domain.Models.Resource", b =>
                {
                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("Resources")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__Resources__Venue__6FE99F9F");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.Sponsor", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("Sponsors")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Sponsors__EventI__73BA3083");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.Supply", b =>
                {
                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("Supplies")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__Supplies__VenueI__72C60C4A");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Users__EmployeeI__68487DD7");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.Volunteer", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("Volunteers")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Volunteer__Event__6EF57B66");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("EmergencyPlans");

                    b.Navigation("EmployeeReports");

                    b.Navigation("EmployeeSchedules");

                    b.Navigation("EmployeeTasks");

                    b.Navigation("EmployeeTrainings");

                    b.Navigation("EmployeeWorkTimes");

                    b.Navigation("EventPlannings");

                    b.Navigation("Events");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Models.Event", b =>
                {
                    b.Navigation("EmergencyPlans");

                    b.Navigation("EmployeeReports");

                    b.Navigation("EmployeeWorkTimes");

                    b.Navigation("EventAttendances");

                    b.Navigation("EventFinances");

                    b.Navigation("EventPlannings");

                    b.Navigation("Sponsors");

                    b.Navigation("Volunteers");
                });

            modelBuilder.Entity("Domain.Models.EventCategory", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Domain.Models.Venue", b =>
                {
                    b.Navigation("EmployeeSchedules");

                    b.Navigation("Events");

                    b.Navigation("Resources");

                    b.Navigation("Supplies");
                });
#pragma warning restore 612, 618
        }
    }
}
