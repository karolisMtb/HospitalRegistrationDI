using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalRegistration.DataAccess.Migrations
{
    public partial class AddedPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientIllnesses_Illnesses_IllnessId",
                table: "PatientIllnesses");

            migrationBuilder.DropIndex(
                name: "IX_PatientIllnesses_IllnessId",
                table: "PatientIllnesses");

            migrationBuilder.DropColumn(
                name: "IllnessId",
                table: "PatientIllnesses");

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_IlnessId",
                table: "PatientIllnesses",
                column: "IlnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientIllnesses_Illnesses_IlnessId",
                table: "PatientIllnesses",
                column: "IlnessId",
                principalTable: "Illnesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientIllnesses_Illnesses_IlnessId",
                table: "PatientIllnesses");

            migrationBuilder.DropIndex(
                name: "IX_PatientIllnesses_IlnessId",
                table: "PatientIllnesses");

            migrationBuilder.AddColumn<Guid>(
                name: "IllnessId",
                table: "PatientIllnesses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PatientIllnesses_IllnessId",
                table: "PatientIllnesses",
                column: "IllnessId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientIllnesses_Illnesses_IllnessId",
                table: "PatientIllnesses",
                column: "IllnessId",
                principalTable: "Illnesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
