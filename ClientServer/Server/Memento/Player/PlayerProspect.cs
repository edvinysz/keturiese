using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Memento.Player
{
    /**
     * Originator
     */
    public class PlayerProspect
    {
        private long _id;
        private string _username;
        private int _deathCount;

        public long Id
        {
            get { return _id; }
            set
            {
                _id = value;
                Console.WriteLine("Id: " + _id);
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                Console.WriteLine("Username: " + _username);
            }
        }

        public int DeathCount
        {
            get { return _deathCount; }
            set
            {
                _deathCount = value;
                Console.WriteLine("DeathCount: " + _deathCount);
            }
        }

        public PlayerMemento saveMemento()
        {
            Console.WriteLine("-- Saving player state --");

            return new PlayerMemento(_id, _username, _deathCount);
        }

        public void restoreMemento(PlayerMemento memento)
        {
            Console.WriteLine("-- Restoring player state --");
            this.Id = memento.Id;
            this.Username = memento.Username;
            this.DeathCount = memento.DeathCount;
        }
    }
}
