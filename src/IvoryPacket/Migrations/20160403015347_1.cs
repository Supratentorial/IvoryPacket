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
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    FamilyName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    GivenName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MedicareCardExpiry = table.Column<DateTimeOffset>(nullable: true),
                    MedicareCardNumber = table.Column<int>(nullable: true),
                    MedicareCardPosition = table.Column<int>(nullable: true),
                    MiddleNames = table.Column<string>(nullable: true),
                    PreferredName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });
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
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PatientPatientId = table.Column<int>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
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
                name: "Allergy",
                columns: table => new
                {
                    AllergyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClinicalManifestation = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    RecordedDate = table.Column<DateTimeOffset>(nullable: true),
                    Severity = table.Column<string>(nullable: true),
                    Substance = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.AllergyId);
                    table.ForeignKey(
                        name: "FK_Allergy_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    EmailAddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailValue = table.Column<string>(nullable: false),
                    IsPreferred = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.EmailAddressId);
                    table.ForeignKey(
                        name: "FK_EmailAddress_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    PhoneNumberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: false),
                    IsPreferred = table.Column<bool>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "SocialHistoryObservation",
                columns: table => new
                {
                    SocialHistoryObservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgeSmokingCeased = table.Column<int>(nullable: false),
                    AgeSmokingCommenced = table.Column<int>(nullable: false),
                    AlcoholStatus = table.Column<string>(nullable: true),
                    CigarettesPerDay = table.Column<int>(nullable: false),
                    DrinksPerDay = table.Column<string>(nullable: true),
                    Ethnicity = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    SmokingStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialHistoryObservation", x => x.SocialHistoryObservationId);
                    table.ForeignKey(
                        name: "FK_SocialHistoryObservation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "VitalSign",
                columns: table => new
                {
                    VitalSignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateRecorded = table.Column<DateTime>(nullable: false),
                    DiastolicBloodPressure = table.Column<int>(nullable: false),
                    HeartRate = table.Column<int>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    OxygenSaturation = table.Column<int>(nullable: false),
                    RespiratoryRate = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: false),
                    SystolicBloodPressure = table.Column<int>(nullable: false),
                    Temperature = table.Column<float>(nullable: false),
                    Weight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSign", x => x.VitalSignId);
                    table.ForeignKey(
                        name: "FK_VitalSign_Patient_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Address");
            migrationBuilder.DropTable("Allergy");
            migrationBuilder.DropTable("EmailAddress");
            migrationBuilder.DropTable("Encounter");
            migrationBuilder.DropTable("PhoneNumber");
            migrationBuilder.DropTable("SocialHistoryObservation");
            migrationBuilder.DropTable("VitalSign");
            migrationBuilder.DropTable("StaffMember");
            migrationBuilder.DropTable("Patient");
        }
    }
}
