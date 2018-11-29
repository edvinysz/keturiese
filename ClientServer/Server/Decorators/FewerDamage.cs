using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Decorators
{
    public class FewerDamage : BlockDecorator
    {
        const int FEWER_DAMAGE = 15;

        public FewerDamage(IBlock block) : base(block)
        {

        }

        public override string getName()
        {
            return base.getName() + " with fewer damage";
        }

        public override int getDamage()
        {
            return base.getDamage() - FEWER_DAMAGE;
        }
    }
}
