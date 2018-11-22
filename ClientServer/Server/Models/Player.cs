using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Observers;

namespace Server.Models
{
    public class Player : Position, IObserver
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public int DeathCount { get; set; }

        public void notify(string message)
        {
            Console.WriteLine("Player " + Username + " notified: \"" + message + "\"");
        }
    }
}
