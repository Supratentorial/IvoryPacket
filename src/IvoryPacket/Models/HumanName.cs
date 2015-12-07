using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvoryPacket.Models
{
    public class HumanName
    {
        public int HumanNameId { get; set; }
        public string Use { get; set; }
        //Text representation of the full name
        public string Text { get; set; }
        public string Family { get; set; }
        public string Given { get; set; }
    }
}
