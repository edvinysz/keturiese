using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    public class BlockFactory : Block
    {
        public NormalBlock createNormalS()
        {
            return new SmallBlock(4, "Mazas", 5, 4, 5, 0);
        }
        public NormalBlock createNormalB()
        {
            return new BigBlock(4, "Didelis", 5, 40, 15, 0);
        }
        public EnemyBlock createEnemyH()
        {
            return new HarmlessBlock(4, "Daro dmg", 5, 4, 5, 1);
        }
        public EnemyBlock createEnemyD()
        {
            return new DeadlyBlock(4, "Mirtinas", 5, 4, 15, 15);
        }
    }
}
