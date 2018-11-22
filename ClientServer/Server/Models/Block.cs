using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Block : Position
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ImageId { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
