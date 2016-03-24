using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvoryPacket.Models
{
    public class VitalSign
    {
        public int VitalSignId { get; set; }
        public ICollection<Observation> Observations { get; set; }

    }
}
