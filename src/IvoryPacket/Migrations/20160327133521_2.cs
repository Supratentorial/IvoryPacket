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
            migrationBuilder.DropForeignKey(name: "FK_EmailAddress_Patient_PatientId", table: "EmailAddress");
            migrationBuilder.DropForeignKey(name: "FK_Encounter_StaffMember_ClinicianId", table: "Encounter");
            migrationBuilder.DropForeignKey(name: "FK_Encounter_Patient_PatientId", table: "Encounter");
            migrationBuilder.DropForeignKey(name: "FK_PhoneNumber_Patient_PatientPatientId", table: "PhoneNumber");
            migrationBuilder.DropColumn(name: "PatientPatientId", table: "PhoneNumber");
            migrationBuilder.DropColumn(name: "Ethnicity", table: "Patient");
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PhoneNumber",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PhoneNumber",
                nullable: false);
            migrationBuilder.AlterColumn<bool>(
                name: "IsPreferred",
                table: "PhoneNumber",
                nullable: true);
            migrationBuilder.AlterColumn<int>(
                name: "CountryCode",
                table: "PhoneNumber",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PhoneNumber",
                nullable: false,
                defaultValue: 0);
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
            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Patient_PatientId",
                table: "PhoneNumber",
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
            migrationBuilder.DropForeignKey(name: "FK_PhoneNumber_Patient_PatientId", table: "PhoneNumber");
            migrationBuilder.DropColumn(name: "PatientId", table: "PhoneNumber");
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "PhoneNumber",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "PhoneNumber",
                nullable: true);
            migrationBuilder.AlterColumn<bool>(
                name: "IsPreferred",
                table: "PhoneNumber",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "PhoneNumber",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "PatientPatientId",
                table: "PhoneNumber",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Ethnicity",
                table: "Patient",
                nullable: true);
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
            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Patient_PatientPatientId",
                table: "PhoneNumber",
                column: "PatientPatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
