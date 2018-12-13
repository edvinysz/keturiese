using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.AbstractFactory
{
    public abstract class BlockFactory
    {
        public abstract EnemyBlock CreateEnemyBlock(string type);
        public abstract NormalBlock CreateNormalBlock(string type);
    }
}
