using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IvoryPacket.Models;

namespace IvoryPacket.Migrations
{
    [DbContext(typeof(IvoryPacketDbContext))]
    [Migration("20160728143028_0")]
    partial class _0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
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

                    b.HasIndex("PatientId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("IvoryPacket.Models.AlcoholHistory", b =>
                {
                    b.Property<int>("AlcoholHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlcoholStatus");

                    b.Property<string>("DrinksPerDay");

                    b.Property<int>("PatientId");

                    b.HasKey("AlcoholHistoryId");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("AlcoholHistory");
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

                    b.HasIndex("PatientId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("IvoryPacket.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AppointmentTime");

                    b.Property<string>("AppointmentType");

                    b.Property<int>("PatientId");

                    b.HasKey("AppointmentId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("IvoryPacket.Models.DrugHistory", b =>
                {
                    b.Property<int>("DrugHistoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PatientId");

                    b.HasKey("DrugHistoryId");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("DrugHistory");
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

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("IvoryPacket.Models.Encounter", b =>
                {
                    b.Property<int>("EncounterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicianId");

                    b.Property<int>("PatientId");

                    b.Property<DateTimeOffset>("RecordedDate");

                    b.HasKey("EncounterId");

                    b.HasIndex("ClinicianId");

                    b.HasIndex("PatientId");

                    b.ToTable("Encounters");
                });

            modelBuilder.Entity("IvoryPacket.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("Date");

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

                    b.ToTable("Patients");
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

                    b.HasIndex("PatientId");

                    b.ToTable("PhoneNumbers");
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

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("SmokingHistory");
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

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("SocialHistory");
                });

            modelBuilder.Entity("IvoryPacket.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FamilyName")
                        .IsRequired();

                    b.Property<string>("GivenName")
                        .IsRequired();

                    b.Property<string>("ProviderNumber");

                    b.Property<string>("Role")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.HasKey("UserId");

                    b.ToTable("Users");
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

                    b.HasIndex("PatientId");

                    b.ToTable("VitalSigns");
                });

            modelBuilder.Entity("IvoryPacket.Models.Address", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithMany("Addresses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.AlcoholHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithOne("AlcoholHistory")
                        .HasForeignKey("IvoryPacket.Models.AlcoholHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.Allergy", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithMany("Allergies")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.Appointment", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.DrugHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithOne("DrugHistory")
                        .HasForeignKey("IvoryPacket.Models.DrugHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.EmailAddress", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithOne("EmailAddress")
                        .HasForeignKey("IvoryPacket.Models.EmailAddress", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.Encounter", b =>
                {
                    b.HasOne("IvoryPacket.Models.User", "Clinician")
                        .WithMany()
                        .HasForeignKey("ClinicianId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.PhoneNumber", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.SmokingHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithOne("SmokingHistory")
                        .HasForeignKey("IvoryPacket.Models.SmokingHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.SocialHistory", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithOne("SocialHistory")
                        .HasForeignKey("IvoryPacket.Models.SocialHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IvoryPacket.Models.VitalSign", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient", "Patient")
                        .WithMany("VitalSigns")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
