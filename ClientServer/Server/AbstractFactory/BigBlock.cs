using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.AbstractFactory
{
    class BigBlock : NormalBlock
    {
        public BigBlock()
        {
            this.Id = 3;
            this.Name = "Big Block";
            this.ImageId = 3;
            this.Width = 20;
            this.Height = 20;
            this.Damage = 0;
        }

    }
}
