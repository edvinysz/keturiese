using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.AbstractFactory;
using Server.Models;

namespace Server.Adapter
{
    public class ChangeHeight
    {
        public void Change(Block block)
        {
            block.Height = 50;
        }
    }
}
