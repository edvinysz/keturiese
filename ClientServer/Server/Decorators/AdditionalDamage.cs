using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Decorators
{
    public class AdditionalDamage : BlockDecorator
    {
        const int ADDITIONAL_DAMAGE = 15;

        public AdditionalDamage(IBlock block) : base(block)
        {
        
        }

        public override string getName()
        {
            return base.getName() + " with additional damage";
        }

        public override int getDamage()
        {
            return base.getDamage() + ADDITIONAL_DAMAGE;
        }
    }
}
