using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace IvoryPacket.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropForeignKey(name: "FK_ContactPoint_Patient_PatientId", table: "ContactPoint");
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedicareCardExpiry",
                table: "Patient",
                nullable: true);
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patient",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patient_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ContactPoint_Patient_PatientId",
                table: "ContactPoint",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropForeignKey(name: "FK_ContactPoint_Patient_PatientId", table: "ContactPoint");
            migrationBuilder.AlterColumn<DateTime>(
                name: "MedicareCardExpiry",
                table: "Patient",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patient",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patient_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ContactPoint_Patient_PatientId",
                table: "ContactPoint",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
