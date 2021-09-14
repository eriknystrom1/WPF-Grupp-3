using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WPF.EmployeeManagement.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: false),
                    Phonenumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMeeting",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    MeetingsMeetingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMeeting", x => new { x.EmployeesId, x.MeetingsMeetingID });
                    table.ForeignKey(
                        name: "FK_EmployeeMeeting_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMeeting_Meetings_MeetingsMeetingID",
                        column: x => x.MeetingsMeetingID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Firstname", "Lastname", "Phonenumber" },
                values: new object[,]
                {
                    { 1, 1, "johnny@gmail.com", "Rafael", "Milanes", 112 },
                    { 2, 1, "Juan@gmail.com", "Johnny", "Cage", 112 },
                    { 3, 2, "Anna@gmail.com", "Anna", "Lindgren", 112 },
                    { 4, 3, "John@gmail.com", "Juanete", "Pérez", 112 },
                    { 5, 3, "new@gmail.com", "New", "SuperNew", 112 }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "MeetingID", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 14, 13, 29, 7, 199, DateTimeKind.Local).AddTicks(3190), new DateTime(2021, 9, 14, 13, 29, 7, 185, DateTimeKind.Local).AddTicks(9812), "Rum 1" },
                    { 2, new DateTime(2021, 9, 14, 13, 29, 7, 199, DateTimeKind.Local).AddTicks(4556), new DateTime(2021, 9, 14, 13, 29, 7, 199, DateTimeKind.Local).AddTicks(4527), "Rum 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMeeting_MeetingsMeetingID",
                table: "EmployeeMeeting",
                column: "MeetingsMeetingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeMeeting");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
