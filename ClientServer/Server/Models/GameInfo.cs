using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public abstract class GameInfo
    {
        public long Id { get; set; }
        public string GameTitle { get; set; }
        public long MapId { get; set; }
        public double GameTime { get; set; }
        public long Player1Id { get; set; }
        public long Player2Id { get; set; }
        public long Player3Id { get; set; }
        public long Player4Id { get; set; }
        public int ConnectedPlayersCount { get; set; }
        public long ResultTableId { get; set; }
        public bool HasStarted { get; set; }
        public bool HasEnded { get; set; }

        public abstract GameInfo Clone();
    }
}
