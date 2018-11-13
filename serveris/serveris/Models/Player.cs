using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serveris.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public int DeathCount { get; set; }
    }
}
