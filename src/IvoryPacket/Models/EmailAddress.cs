using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvoryPacket.Models
{
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        public string EmailValue { get; set; }
        public bool IsPreferred { get; set; }
    }
}
