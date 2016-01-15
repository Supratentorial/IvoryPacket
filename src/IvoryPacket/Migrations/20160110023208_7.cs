using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace IvoryPacket.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Patient",
                type: "Date",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patient_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
