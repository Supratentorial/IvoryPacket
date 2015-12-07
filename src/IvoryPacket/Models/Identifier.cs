using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvoryPacket.Models
{
    public class Identifier
    {
        public string Use { get; set; }
        public string Value { get; set; }
        public Period Period { get; set; }
        public virtual Organisation MyProperty { get; set; }
    }
}
