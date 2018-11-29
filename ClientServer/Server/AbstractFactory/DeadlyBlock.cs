using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.AbstractFactory
{
    class DeadlyBlock : EnemyBlock
    {
        public DeadlyBlock()
        {
            this.Id = 4;
            this.Name = "Deadly Block";
            this.ImageId = 4;
            this.Width = 10;
            this.Height = 10;
            this.Damage = 10;
        }
    }
}
