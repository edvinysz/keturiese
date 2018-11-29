using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.AbstractFactory
{
    class HarmlessBlock : EnemyBlock
    {
        public HarmlessBlock()
        {
            this.Id = 2;
            this.Name = "Harmless Block";
            this.ImageId = 2;
            this.Width = 20;
            this.Height = 20;
            this.Damage = 1;
        }
    }
}
