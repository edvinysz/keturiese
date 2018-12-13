using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Decorators
{
    public abstract class BlockDecorator : IBlock
    {
        private IBlock _block = null;

        public BlockDecorator(IBlock block)
        {
            this._block = block;
        }

        public virtual string getName()
        {
            return this._block.getName();
        }

        public virtual int getDamage()
        {
            return this._block.getDamage();
        }

        public override string ToString()
        {
            return "Block info | Name: " + this.getName() + ", Damage: " + this.getDamage();
        }
    }
}
