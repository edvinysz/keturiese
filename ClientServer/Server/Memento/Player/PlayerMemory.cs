using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Memento.Player
{
    /**
     * Caretaker
     */
    public class PlayerMemory
    {
        private PlayerMemento _memento;

        public PlayerMemento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
