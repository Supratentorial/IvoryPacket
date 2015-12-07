using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace IvoryPacket.Models
{
    public class IvoryPacketDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder) { }
    }
}
