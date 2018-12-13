using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Adapter
{
    public class MoveAdapter
    {
        public virtual void Move(Block block)
        {
            Console.WriteLine("Called Move()");
        }
    }
}
