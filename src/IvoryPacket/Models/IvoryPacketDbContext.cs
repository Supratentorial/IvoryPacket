using Microsoft.Data.Entity;

namespace IvoryPacket.Models
{
    public class IvoryPacketDbContext : DbContext
    {
        public IvoryPacketDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ContactPoint> ContactPoints { get; set; }
    }
}
