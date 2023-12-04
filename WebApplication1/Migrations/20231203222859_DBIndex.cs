using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DBIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.IdCourse);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    IdGrade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.IdGrade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    idStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGrade = table.Column<int>(type: "int", nullable: false),
                    GradeIdGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.idStudent);
                    table.ForeignKey(
                        name: "FK_Student_Grade_GradeIdGrade",
                        column: x => x.GradeIdGrade,
                        principalTable: "Grade",
                        principalColumn: "IdGrade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    idEnrollment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idStudent = table.Column<int>(type: "int", nullable: false),
                    StudentidStudent = table.Column<int>(type: "int", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false),
                    CourseIdCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.idEnrollment);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseIdCourse",
                        column: x => x.CourseIdCourse,
                        principalTable: "Course",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentidStudent",
                        column: x => x.StudentidStudent,
                        principalTable: "Student",
                        principalColumn: "idStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseIdCourse",
                table: "Enrollment",
                column: "CourseIdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentidStudent",
                table: "Enrollment",
                column: "StudentidStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeIdGrade",
                table: "Student",
                column: "GradeIdGrade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Grade");
        }
    }
}
