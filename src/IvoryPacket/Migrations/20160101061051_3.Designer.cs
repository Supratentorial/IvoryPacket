using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using IvoryPacket.Models;

namespace IvoryPacket.Migrations
{
    [DbContext(typeof(IvoryPacketDbContext))]
    [Migration("20160101061051_3")]
    partial class _3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("IvoryPacket.Models.ContactPoint", b =>
                {
                    b.Property<int>("ContactPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PatientId");

                    b.Property<int?>("Rank");

                    b.Property<string>("System");

                    b.Property<string>("Use");

                    b.Property<string>("Value");

                    b.HasKey("ContactPointId");
                });

            modelBuilder.Entity("IvoryPacket.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("DateOfBirth");

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

            modelBuilder.Entity("IvoryPacket.Models.Allergy", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("IvoryPacket.Models.ContactPoint", b =>
                {
                    b.HasOne("IvoryPacket.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });
        }
    }
}
