using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Server.Models;

namespace Server.AbstractFactory
{ 
    class SmallBlock : NormalBlock
    {
        public SmallBlock()
        {
            this.Id = 1;
            this.Name = "Small Block";
            this.ImageId = 1;
            this.Width = 5;
            this.Height = 5;
            this.Damage = 0;
        }
    }
}
