using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    EventCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.EventCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    AttendeeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FeedbackText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackID);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartnerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerID);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueID);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceID);
                    table.ForeignKey(
                        name: "FK__Resources__Venue__6A30C649",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID");
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    SupplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.SupplyID);
                    table.ForeignKey(
                        name: "FK__Supplies__VenueI__6D0D32F4",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentHeadID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValueSql: "('Staff')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK__Employee__Depart__6477ECF3",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventDate = table.Column<DateTime>(type: "date", nullable: false),
                    EventCategoryID = table.Column<int>(type: "int", nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false),
                    ResponsibleStaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK__Events__EventCat__656C112C",
                        column: x => x.EventCategoryID,
                        principalTable: "EventCategories",
                        principalColumn: "EventCategoryID");
                    table.ForeignKey(
                        name: "FK__Events__Responsi__6754599E",
                        column: x => x.ResponsibleStaffID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__Events__VenueID__66603565",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID");
                });

            migrationBuilder.CreateTable(
                name: "StaffSchedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStart = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShiftEnd = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    VenueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StaffSch__9C8A5B69BE89F9F7", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK__StaffSche__Emplo__75A278F5",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__StaffSche__Venue__76969D2E",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID");
                });

            migrationBuilder.CreateTable(
                name: "StaffTasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AssignedStaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StaffTas__7C6949D15911892C", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK__StaffTask__Assig__68487DD7",
                        column: x => x.AssignedStaffID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "StaffTraining",
                columns: table => new
                {
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StaffTra__E8D71DE2C8F980D4", x => x.TrainingID);
                    table.ForeignKey(
                        name: "FK__StaffTrai__Emplo__71D1E811",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__Users__EmployeeI__4222D4EF",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "EmergencyPlans",
                columns: table => new
                {
                    PlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmergencyDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    ResponsibleStaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emergenc__755C22D7F2E147C9", x => x.PlanID);
                    table.ForeignKey(
                        name: "FK__Emergency__Event__778AC167",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                    table.ForeignKey(
                        name: "FK__Emergency__Respo__787EE5A0",
                        column: x => x.ResponsibleStaffID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "EventAttendance",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendeeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventAtt__8B69263CC280A022", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK__EventAtte__Event__70DDC3D8",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "EventFinance",
                columns: table => new
                {
                    FinanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventFin__7917A8FF33592B85", x => x.FinanceID);
                    table.ForeignKey(
                        name: "FK__EventFina__Event__74AE54BC",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "EventPlanning",
                columns: table => new
                {
                    PlanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    ResponsibleStaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventPla__755C22D7125023CB", x => x.PlanID);
                    table.ForeignKey(
                        name: "FK__EventPlan__Event__6B24EA82",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                    table.ForeignKey(
                        name: "FK__EventPlan__Respo__6C190EBB",
                        column: x => x.ResponsibleStaffID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    SponsorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SponsorName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.SponsorID);
                    table.ForeignKey(
                        name: "FK__Sponsors__EventI__6E01572D",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "StaffReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StaffRep__D5BD48E5EB9C22E2", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK__StaffRepo__Emplo__6EF57B66",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__StaffRepo__Event__6FE99F9F",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "StaffWorkTime",
                columns: table => new
                {
                    WorkTimeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StaffWor__E4A9C6597ABC0A03", x => x.WorkTimeID);
                    table.ForeignKey(
                        name: "FK__StaffWork__Emplo__72C60C4A",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__StaffWork__Event__73BA3083",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerID);
                    table.ForeignKey(
                        name: "FK__Volunteer__Event__693CA210",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentHeadID",
                table: "Departments",
                column: "DepartmentHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyPlans_EventID",
                table: "EmergencyPlans",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyPlans_ResponsibleStaffID",
                table: "EmergencyPlans",
                column: "ResponsibleStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAttendance_EventID",
                table: "EventAttendance",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventFinance_EventID",
                table: "EventFinance",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlanning_EventID",
                table: "EventPlanning",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPlanning_ResponsibleStaffID",
                table: "EventPlanning",
                column: "ResponsibleStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventCategoryID",
                table: "Events",
                column: "EventCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResponsibleStaffID",
                table: "Events",
                column: "ResponsibleStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueID",
                table: "Events",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_VenueID",
                table: "Resources",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_EventID",
                table: "Sponsors",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffReports_EmployeeID",
                table: "StaffReports",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffReports_EventID",
                table: "StaffReports",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSchedule_EmployeeID",
                table: "StaffSchedule",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffSchedule_VenueID",
                table: "StaffSchedule",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffTasks_AssignedStaffID",
                table: "StaffTasks",
                column: "AssignedStaffID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffTraining_EmployeeID",
                table: "StaffTraining",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffWorkTime_EmployeeID",
                table: "StaffWorkTime",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffWorkTime_EventID",
                table: "StaffWorkTime",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_VenueID",
                table: "Supplies",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__536C85E45C3D8BD0",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_EventID",
                table: "Volunteers",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK__Departmen__Depar__6383C8BA",
                table: "Departments",
                column: "DepartmentHeadID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Departmen__Depar__6383C8BA",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "EmergencyPlans");

            migrationBuilder.DropTable(
                name: "EventAttendance");

            migrationBuilder.DropTable(
                name: "EventFinance");

            migrationBuilder.DropTable(
                name: "EventPlanning");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "StaffReports");

            migrationBuilder.DropTable(
                name: "StaffSchedule");

            migrationBuilder.DropTable(
                name: "StaffTasks");

            migrationBuilder.DropTable(
                name: "StaffTraining");

            migrationBuilder.DropTable(
                name: "StaffWorkTime");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
