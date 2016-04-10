using Microsoft.Data.Entity;

namespace IvoryPacket.Models
{
    public class IvoryPacketDbContext : DbContext
    {
        public IvoryPacketDbContext() : base()
        {
            Database.EnsureCreated();
        }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<StaffMember>().HasKey(s => s.StaffId);
            modelBuilder.Entity<SmokingHistory>().HasKey(s => s.SmokingHistoryId);
        }
    }
}
