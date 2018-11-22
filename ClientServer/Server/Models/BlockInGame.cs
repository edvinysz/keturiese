using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BlockInGame : Block
    {
        public long Id { get; set; }
        public long BlockId { get; set; }
        public bool IsFinish { get; set; }
        public bool GiveDamage { get; set; }
        public long PositionId { get; set; }
    }
}
