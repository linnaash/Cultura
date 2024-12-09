﻿// <auto-generated />
using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Cultura_bdContext))]
    [Migration("20241209113902_User_update")]
    partial class User_update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("ResponsibleStaffId")
                        .HasColumnType("int")
                        .HasColumnName("ResponsibleStaffID");

                    b.HasKey("PlanId")
                        .HasName("PK__Emergenc__755C22D7F2E147C9");

                    b.HasIndex("EventId");

                    b.HasIndex("ResponsibleStaffId");

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

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasDefaultValueSql("('Staff')");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee", (string)null);
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

                    b.Property<int>("ResponsibleStaffId")
                        .HasColumnType("int")
                        .HasColumnName("ResponsibleStaffID");

                    b.Property<int>("VenueId")
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    b.HasKey("EventId");

                    b.HasIndex("EventCategoryId");

                    b.HasIndex("ResponsibleStaffId");

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
                        .HasName("PK__EventAtt__8B69263CC280A022");

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
                        .HasName("PK__EventFin__7917A8FF33592B85");

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

                    b.Property<int>("ResponsibleStaffId")
                        .HasColumnType("int")
                        .HasColumnName("ResponsibleStaffID");

                    b.HasKey("PlanId")
                        .HasName("PK__EventPla__755C22D7125023CB");

                    b.HasIndex("EventId");

                    b.HasIndex("ResponsibleStaffId");

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

            modelBuilder.Entity("Domain.Models.Partner", b =>
                {
                    b.Property<int>("PartnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PartnerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartnerId"), 1L, 1);

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PartnerName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PartnerId");

                    b.ToTable("Partners");
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

            modelBuilder.Entity("Domain.Models.StaffReport", b =>
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
                        .HasName("PK__StaffRep__D5BD48E5EB9C22E2");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EventId");

                    b.ToTable("StaffReports");
                });

            modelBuilder.Entity("Domain.Models.StaffSchedule", b =>
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
                        .HasName("PK__StaffSch__9C8A5B69BE89F9F7");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VenueId");

                    b.ToTable("StaffSchedule", (string)null);
                });

            modelBuilder.Entity("Domain.Models.StaffTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TaskID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<int>("AssignedStaffId")
                        .HasColumnType("int")
                        .HasColumnName("AssignedStaffID");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TaskId")
                        .HasName("PK__StaffTas__7C6949D15911892C");

                    b.HasIndex("AssignedStaffId");

                    b.ToTable("StaffTasks");
                });

            modelBuilder.Entity("Domain.Models.StaffTraining", b =>
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
                        .HasName("PK__StaffTra__E8D71DE2C8F980D4");

                    b.HasIndex("EmployeeId");

                    b.ToTable("StaffTraining", (string)null);
                });

            modelBuilder.Entity("Domain.Models.StaffWorkTime", b =>
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
                        .HasName("PK__StaffWor__E4A9C6597ABC0A03");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EventId");

                    b.ToTable("StaffWorkTime", (string)null);
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
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("EmployeeID");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("EmployeeId");

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
                        .HasConstraintName("FK__Departmen__Depar__6383C8BA");

                    b.Navigation("DepartmentHead");
                });

            modelBuilder.Entity("Domain.Models.EmergencyPlan", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EmergencyPlans")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Emergency__Event__778AC167");

                    b.HasOne("Domain.Models.Employee", "ResponsibleStaff")
                        .WithMany("EmergencyPlans")
                        .HasForeignKey("ResponsibleStaffId")
                        .IsRequired()
                        .HasConstraintName("FK__Emergency__Respo__787EE5A0");

                    b.Navigation("Event");

                    b.Navigation("ResponsibleStaff");
                });

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.HasOne("Domain.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Employee__Depart__6477ECF3");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Domain.Models.Event", b =>
                {
                    b.HasOne("Domain.Models.EventCategory", "EventCategory")
                        .WithMany("Events")
                        .HasForeignKey("EventCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__EventCat__656C112C");

                    b.HasOne("Domain.Models.Employee", "ResponsibleStaff")
                        .WithMany("Events")
                        .HasForeignKey("ResponsibleStaffId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__Responsi__6754599E");

                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__Events__VenueID__66603565");

                    b.Navigation("EventCategory");

                    b.Navigation("ResponsibleStaff");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.EventAttendance", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EventAttendances")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventAtte__Event__70DDC3D8");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.EventFinance", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EventFinances")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventFina__Event__74AE54BC");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.EventPlanning", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("EventPlannings")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__EventPlan__Event__6B24EA82");

                    b.HasOne("Domain.Models.Employee", "ResponsibleStaff")
                        .WithMany("EventPlannings")
                        .HasForeignKey("ResponsibleStaffId")
                        .IsRequired()
                        .HasConstraintName("FK__EventPlan__Respo__6C190EBB");

                    b.Navigation("Event");

                    b.Navigation("ResponsibleStaff");
                });

            modelBuilder.Entity("Domain.Models.Resource", b =>
                {
                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("Resources")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__Resources__Venue__6A30C649");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.Sponsor", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("Sponsors")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Sponsors__EventI__6E01572D");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.StaffReport", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("StaffReports")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__StaffRepo__Emplo__6EF57B66");

                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("StaffReports")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__StaffRepo__Event__6FE99F9F");

                    b.Navigation("Employee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.StaffSchedule", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("StaffSchedules")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__StaffSche__Emplo__75A278F5");

                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("StaffSchedules")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__StaffSche__Venue__76969D2E");

                    b.Navigation("Employee");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.StaffTask", b =>
                {
                    b.HasOne("Domain.Models.Employee", "AssignedStaff")
                        .WithMany("StaffTasks")
                        .HasForeignKey("AssignedStaffId")
                        .IsRequired()
                        .HasConstraintName("FK__StaffTask__Assig__68487DD7");

                    b.Navigation("AssignedStaff");
                });

            modelBuilder.Entity("Domain.Models.StaffTraining", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("StaffTrainings")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__StaffTrai__Emplo__71D1E811");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.StaffWorkTime", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("StaffWorkTimes")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__StaffWork__Emplo__72C60C4A");

                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("StaffWorkTimes")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__StaffWork__Event__73BA3083");

                    b.Navigation("Employee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Domain.Models.Supply", b =>
                {
                    b.HasOne("Domain.Models.Venue", "Venue")
                        .WithMany("Supplies")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__Supplies__VenueI__6D0D32F4");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Employee", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__Users__EmployeeI__4222D4EF");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Models.Volunteer", b =>
                {
                    b.HasOne("Domain.Models.Event", "Event")
                        .WithMany("Volunteers")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Volunteer__Event__693CA210");

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

                    b.Navigation("EventPlannings");

                    b.Navigation("Events");

                    b.Navigation("StaffReports");

                    b.Navigation("StaffSchedules");

                    b.Navigation("StaffTasks");

                    b.Navigation("StaffTrainings");

                    b.Navigation("StaffWorkTimes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Models.Event", b =>
                {
                    b.Navigation("EmergencyPlans");

                    b.Navigation("EventAttendances");

                    b.Navigation("EventFinances");

                    b.Navigation("EventPlannings");

                    b.Navigation("Sponsors");

                    b.Navigation("StaffReports");

                    b.Navigation("StaffWorkTimes");

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
                    b.Navigation("Events");

                    b.Navigation("Resources");

                    b.Navigation("StaffSchedules");

                    b.Navigation("Supplies");
                });
#pragma warning restore 612, 618
        }
    }
}
