using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Iterators;
using Server.Models;

namespace Server.Iterators.Block
{
    public class BlockCollection : AbstractCollection
    {
        private List<IBlock> _items = new List<IBlock>();

        public override AbstractIterator createIterator()
        {
            return new BlockIterator(this);
        }

        public int count
        {
            get { return _items.Count; }
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, (IBlock)value); }
        }
    }
}
