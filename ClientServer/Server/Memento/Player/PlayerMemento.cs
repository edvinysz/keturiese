using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Memento.Player
{
    /**
     * Memento
     */
    public class PlayerMemento
    {
        private long _id;
        private string _username;
        private int _deathCount;

        public PlayerMemento(long id, string username, int deathCount)
        {
            this._id = id;
            this._username = username;
            this._deathCount = deathCount;
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public int DeathCount
        {
            get { return _deathCount; }
            set { _deathCount = value; }
        }
    }
}
