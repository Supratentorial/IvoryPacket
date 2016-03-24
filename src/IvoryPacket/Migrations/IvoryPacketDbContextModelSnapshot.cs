using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using IvoryPacket.Models;

namespace IvoryPacket.Migrations
{
    [DbContext(typeof(IvoryPacketDbContext))]
    partial class IvoryPacketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IvoryPacket.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int?>("PatientPatientId");

                    b.Property<string>("PostalCode");

                    b.Property<string>("State");

                    b.Property<string>("Type");

                    b.HasKey("AddressId");
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

            modelBuilder.Entity("IvoryPacket.Models.EmailAddress", b =>
                {
                    b.Property<int>("EmailAddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailValue");

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

                    b.Property<string>("Ethnicity");

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

                    b.Property<string>("CountryCode");

                    b.Property<bool>("IsPreferred");

                    b.Property<int?>("PatientPatientId");

                    b.Property<string>("Type");

                    b.Property<string>("Value");

                    b.HasKey("PhoneNumberId");
                });

            modelBuilder.Entity("IvoryPacket.Models.StaffMember", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FamilyName");

                    b.Property<string>("GivenName");

                    b.HasKey("StaffId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Address", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientPatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Allergy", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
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
                        .HasForeignKey("PatientPatientId");
                });
        }
    }
}
