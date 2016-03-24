using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace IvoryPacket.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropForeignKey(name: "FK_EmailAddress_Patient_PatientId", table: "EmailAddress");
            migrationBuilder.DropForeignKey(name: "FK_Encounter_StaffMember_ClinicianId", table: "Encounter");
            migrationBuilder.DropForeignKey(name: "FK_Encounter_Patient_PatientId", table: "Encounter");
            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patient_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddress_Patient_PatientId",
                table: "EmailAddress",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Encounter_StaffMember_ClinicianId",
                table: "Encounter",
                column: "ClinicianId",
                principalTable: "StaffMember",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Encounter_Patient_PatientId",
                table: "Encounter",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropForeignKey(name: "FK_EmailAddress_Patient_PatientId", table: "EmailAddress");
            migrationBuilder.DropForeignKey(name: "FK_Encounter_StaffMember_ClinicianId", table: "Encounter");
            migrationBuilder.DropForeignKey(name: "FK_Encounter_Patient_PatientId", table: "Encounter");
            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Patient_PatientId",
                table: "Allergy",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddress_Patient_PatientId",
                table: "EmailAddress",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Encounter_StaffMember_ClinicianId",
                table: "Encounter",
                column: "ClinicianId",
                principalTable: "StaffMember",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Encounter_Patient_PatientId",
                table: "Encounter",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
