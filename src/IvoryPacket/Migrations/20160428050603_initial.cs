using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace IvoryPacket.Migrations
{
    public partial class initial : Migration
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
                    PatientId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AlcoholHistory",
                columns: table => new
                {
                    AlcoholHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlcoholStatus = table.Column<string>(nullable: true),
                    DrinksPerDay = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholHistory", x => x.AlcoholHistoryId);
                    table.ForeignKey(
                        name: "FK_AlcoholHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentTime = table.Column<DateTime>(nullable: true),
                    AppointmentType = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "DrugHistory",
                columns: table => new
                {
                    DrugHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugHistory", x => x.DrugHistoryId);
                    table.ForeignKey(
                        name: "FK_DrugHistory_Patient_PatientId",
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
                name: "SmokingHistory",
                columns: table => new
                {
                    SmokingHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgeSmokingCeased = table.Column<int>(nullable: true),
                    AgeSmokingCommenced = table.Column<int>(nullable: true),
                    CigarettesPerDay = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    SmokingStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmokingHistory", x => x.SmokingHistoryId);
                    table.ForeignKey(
                        name: "FK_SmokingHistory_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "SocialHistory",
                columns: table => new
                {
                    SocialHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ethnicity = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    Religion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialHistory", x => x.SocialHistoryId);
                    table.ForeignKey(
                        name: "FK_SocialHistory_Patient_PatientId",
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
                    DateRecorded = table.Column<DateTime>(nullable: true),
                    DiastolicBloodPressure = table.Column<int>(nullable: true),
                    HeartRate = table.Column<int>(nullable: true),
                    Height = table.Column<float>(nullable: true),
                    OxygenSaturation = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    RespiratoryRate = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SystolicBloodPressure = table.Column<int>(nullable: true),
                    Temperature = table.Column<float>(nullable: true),
                    Weight = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSign", x => x.VitalSignId);
                    table.ForeignKey(
                        name: "FK_VitalSign_Patient_PatientId",
                        column: x => x.PatientId,
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
            migrationBuilder.DropTable("AlcoholHistory");
            migrationBuilder.DropTable("Allergy");
            migrationBuilder.DropTable("Appointment");
            migrationBuilder.DropTable("DrugHistory");
            migrationBuilder.DropTable("EmailAddress");
            migrationBuilder.DropTable("Encounter");
            migrationBuilder.DropTable("PhoneNumber");
            migrationBuilder.DropTable("SmokingHistory");
            migrationBuilder.DropTable("SocialHistory");
            migrationBuilder.DropTable("VitalSign");
            migrationBuilder.DropTable("StaffMember");
            migrationBuilder.DropTable("Patient");
        }
    }
}
