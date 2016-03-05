using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace IvoryPacket.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropForeignKey(name: "FK_EmailAddress_Patient_PatientId", table: "EmailAddress");
            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamilyName = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.StaffId);
                });
            migrationBuilder.CreateTable(
                name: "Encounter",
                columns: table => new
                {
                    EncounterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClinicianId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    RecordedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounter", x => x.EncounterId);
                    table.ForeignKey(
                        name: "FK_Encounter_StaffMember_ClinicianId",
                        column: x => x.ClinicianId,
                        principalTable: "StaffMember",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Encounter_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropForeignKey(name: "FK_EmailAddress_Patient_PatientId", table: "EmailAddress");
            migrationBuilder.DropTable("Encounter");
            migrationBuilder.DropTable("StaffMember");
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
        }
    }
}
