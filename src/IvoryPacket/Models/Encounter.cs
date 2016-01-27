using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IvoryPacket.Models
{
    public class Encounter
    {
        public int EncounterId { get; set; }
        public DateTimeOffset RecordedDate { get; set; }
        public virtual StaffMember Clinician { get; set; }
        public int ClinicianId { get; set; }
        public virtual Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
