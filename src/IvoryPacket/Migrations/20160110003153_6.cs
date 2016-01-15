using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace IvoryPacket.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Patient",
                type: "Date",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patient_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Patient",
                newName: "DateOfBirth");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Patient",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patient_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Patient",
                newName: "Date");
        }
    }
}
