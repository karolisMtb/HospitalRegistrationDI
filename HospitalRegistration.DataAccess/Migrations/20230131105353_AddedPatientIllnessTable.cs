using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalRegistration.DataAccess.Migrations
{
    public partial class AddedPatientIllnessTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Illnesses_IllnessId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_IllnessId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IllnessId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "DoctorPatients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PatientIllnesses",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IlnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IllnessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientIllnesses", x => new { x.PatientId, x.IlnessId });
                    table.ForeignKey(
                        name: "FK_PatientIllnesses_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientIllnesses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_IllnessId",
                table: "PatientIllnesses",
                column: "IllnessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientIllnesses");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "DoctorPatients");

            migrationBuilder.AddColumn<Guid>(
                name: "IllnessId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IllnessId",
                table: "Patients",
                column: "IllnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Illnesses_IllnessId",
                table: "Patients",
                column: "IllnessId",
                principalTable: "Illnesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
