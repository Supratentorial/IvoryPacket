using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using IvoryPacket.Models;

namespace IvoryPacket.Migrations
{
    [DbContext(typeof(IvoryPacketDbContext))]
    [Migration("20160428050603_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IvoryPacket.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("Country");

                    b.Property<int>("PatientId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("Suburb");

                    b.Property<string>("Type");

                    b.HasKey("AddressId");
                });

            modelBuilder.Entity("IvoryPacket.Models.AlcoholHistory", b =>
                {
                    b.Property<int>("AlcoholHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlcoholStatus");

                    b.Property<string>("DrinksPerDay");

                    b.Property<int>("PatientId");

                    b.HasKey("AlcoholHistoryId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Allergy", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClinicalManifestation");

                    b.Property<string>("Note");

                    b.Property<int>("PatientId");

                    b.Property<DateTimeOffset?>("RecordedDate");

                    b.Property<string>("Severity");

                    b.Property<string>("Substance");

                    b.Property<string>("Type");

                    b.HasKey("AllergyId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AppointmentTime");

                    b.Property<string>("AppointmentType");

                    b.Property<int>("PatientId");

                    b.HasKey("AppointmentId");
                });

            modelBuilder.Entity("IvoryPacket.Models.DrugHistory", b =>
                {
                    b.Property<int>("DrugHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PatientId");

                    b.HasKey("DrugHistoryId");
                });

            modelBuilder.Entity("IvoryPacket.Models.EmailAddress", b =>
                {
                    b.Property<int>("EmailAddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailValue")
                        .IsRequired();

                    b.Property<bool>("IsPreferred");

                    b.Property<int>("PatientId");

                    b.HasKey("EmailAddressId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Encounter", b =>
                {
                    b.Property<int>("EncounterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicianId");

                    b.Property<int>("PatientId");

                    b.Property<DateTimeOffset>("RecordedDate");

                    b.HasKey("EncounterId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth")
                        .HasAnnotation("Relational:ColumnType", "Date");

                    b.Property<string>("FamilyName");

                    b.Property<string>("Gender");

                    b.Property<string>("GivenName");

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset?>("MedicareCardExpiry");

                    b.Property<int?>("MedicareCardNumber");

                    b.Property<int?>("MedicareCardPosition");

                    b.Property<string>("MiddleNames");

                    b.Property<string>("PreferredName");

                    b.Property<string>("Title");

                    b.HasKey("PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneNumberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AreaCode");

                    b.Property<string>("CountryCode")
                        .IsRequired();

                    b.Property<bool?>("IsPreferred");

                    b.Property<int>("PatientId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("PhoneNumberId");
                });

            modelBuilder.Entity("IvoryPacket.Models.SmokingHistory", b =>
                {
                    b.Property<int>("SmokingHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AgeSmokingCeased");

                    b.Property<int?>("AgeSmokingCommenced");

                    b.Property<int?>("CigarettesPerDay");

                    b.Property<string>("Notes");

                    b.Property<int>("PatientId");

                    b.Property<string>("SmokingStatus");

                    b.HasKey("SmokingHistoryId");
                });

            modelBuilder.Entity("IvoryPacket.Models.SocialHistory", b =>
                {
                    b.Property<int>("SocialHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ethnicity");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("Occupation");

                    b.Property<int>("PatientId");

                    b.Property<string>("Religion");

                    b.HasKey("SocialHistoryId");
                });

            modelBuilder.Entity("IvoryPacket.Models.StaffMember", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FamilyName");

                    b.Property<string>("GivenName");

                    b.HasKey("StaffId");
                });

            modelBuilder.Entity("IvoryPacket.Models.VitalSign", b =>
                {
                    b.Property<int>("VitalSignId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateRecorded");

                    b.Property<int?>("DiastolicBloodPressure");

                    b.Property<int?>("HeartRate");

                    b.Property<float?>("Height");

                    b.Property<int?>("OxygenSaturation");

                    b.Property<int>("PatientId");

                    b.Property<int?>("RespiratoryRate");

                    b.Property<string>("Status");

                    b.Property<int?>("SystolicBloodPressure");

                    b.Property<float?>("Temperature");

                    b.Property<float?>("Weight");

                    b.HasKey("VitalSignId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Address", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.AlcoholHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithOne()
                        .HasForeignKey("IvoryPacket.Models.AlcoholHistory", "PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Allergy", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Appointment", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.DrugHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithOne()
                        .HasForeignKey("IvoryPacket.Models.DrugHistory", "PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.EmailAddress", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithOne()
                        .HasForeignKey("IvoryPacket.Models.EmailAddress", "PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Encounter", b =>
                {
                    b.HasOne("IvoryPacket.Models.StaffMember")
                        .WithMany()
                        .HasForeignKey("ClinicianId");

                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.PhoneNumber", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.SmokingHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithOne()
                        .HasForeignKey("IvoryPacket.Models.SmokingHistory", "PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.SocialHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithOne()
                        .HasForeignKey("IvoryPacket.Models.SocialHistory", "PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.VitalSign", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });
        }
    }
}
