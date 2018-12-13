using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Iterators.Block
{
    public class BlockIterator : AbstractIterator
    {
        private BlockCollection _collection;
        private int _current = 0;

        public BlockIterator(BlockCollection collection)
        {
            this._collection = collection;
        }

        public override object first()
        {
            return _collection[0];
        }

        public override object next()
        {
            object result = null;

            if (_current < _collection.count - 1)
            {
                result = _collection[++_current];
            }

            return result;
        }

        public override object currentItem()
        {
            return _collection[_current];
        }

        public override bool hasNext()
        {
            return _current < _collection.count;
        }
    }
}
