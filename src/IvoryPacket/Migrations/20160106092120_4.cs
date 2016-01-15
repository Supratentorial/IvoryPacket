using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace IvoryPacket.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropTable("ContactPoint");
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PatientPatientId = table.Column<int>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Patient_PatientPatientId",
                        column: x => x.PatientPatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    EmailAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailValue = table.Column<string>(nullable: true),
                    IsPreferred = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.EmailAddressId);
                });
            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    PhoneNumberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    IsPreferred = table.Column<bool>(nullable: false),
                    PatientPatientId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Patient_PatientPatientId",
                        column: x => x.PatientPatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<int>(
                name: "EmailAddressEmailAddressId",
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
                name: "FK_Patient_EmailAddress_EmailAddressEmailAddressId",
                table: "Patient",
                column: "EmailAddressEmailAddressId",
                principalTable: "EmailAddress",
                principalColumn: "EmailAddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Allergy_Patient_PatientId", table: "Allergy");
            migrationBuilder.DropForeignKey(name: "FK_Patient_EmailAddress_EmailAddressEmailAddressId", table: "Patient");
            migrationBuilder.DropColumn(name: "EmailAddressEmailAddressId", table: "Patient");
            migrationBuilder.DropTable("Address");
            migrationBuilder.DropTable("EmailAddress");
            migrationBuilder.DropTable("PhoneNumber");
            migrationBuilder.CreateTable(
                name: "ContactPoint",
                columns: table => new
                {
                    ContactPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: true),
                    System = table.Column<string>(nullable: true),
                    Use = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPoint", x => x.ContactPointId);
                    table.ForeignKey(
                        name: "FK_ContactPoint_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });
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
