using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Player : Position
    {
        /**private int Id;
        private string Username;
        private int DeathCount;*/
        public long Id { get; set; }
        public string Username { get; set; }
        public int DeathCount { get; set; }

        /**public Player(int id, string username, int deathCount)
        {
            this.Id = id;
            this.Username = username;
            this.DeathCount = deathCount;
        }*/
    }
}
