using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serveris.Models
{
    public class BlockInGame
    {
        public long Id { get; set; }
        public long BlockId { get; set; }
        public bool IsFinish { get; set; }
        public bool GiveDamage { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
