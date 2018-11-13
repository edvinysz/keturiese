using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serveris.Models
{
    public class Map
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<BlockInGame> Blocks { get; set; }
    }
}
