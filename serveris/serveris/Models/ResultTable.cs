using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serveris.Models
{
    public class ResultTable
    {
        public long Id { get; set; }
        public long GameInfoId { get; set; }
        public string GameTitle { get; set; }
        public long MapId { get; set; }

        public long Player1Id { get; set; } //Winner
        public long Player2Id { get; set; }
        public long Player3Id { get; set; }
        public long Player4Id { get; set; } //Looser
        public long Player1DeathCount { get; set; }
        public long Player2DeathCount { get; set; }
        public long Player3DeathCount { get; set; }
        public long Player4DeathCount { get; set; }
    }
}
