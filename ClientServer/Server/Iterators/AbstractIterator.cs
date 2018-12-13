using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Iterators
{
    public abstract class AbstractIterator
    {
        public abstract object first();

        public abstract object next();

        public abstract object currentItem();

        public abstract bool hasNext();
    }
}