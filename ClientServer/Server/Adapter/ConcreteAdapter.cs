using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.AbstractFactory;
using Server.Models;

namespace Server.Adapter
{
    public class ConcreteAdapter : MoveAdapter
    {
        private ChangeHeight adaptee = new ChangeHeight();

        public override void Move(Block block)
        {
            adaptee.Change(block);
        }
    }
}
