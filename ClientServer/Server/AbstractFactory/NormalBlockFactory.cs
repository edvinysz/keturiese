using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.AbstractFactory
{
    public class NormalBlockFactory : BlockFactory
    {
        public override EnemyBlock CreateEnemyBlock(string type)
        {
            if (type == "Deadly")
                return new DeadlyBlock();

            return new HarmlessBlock();
        }

        public override NormalBlock CreateNormalBlock(string type)
        {
            if (type == "Small")
                return new SmallBlock();

            return new BigBlock();
        }
    }
}
