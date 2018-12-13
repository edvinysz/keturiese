using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Iterators
{
    public abstract class AbstractCollection
    {
        public abstract AbstractIterator createIterator();
    }
}
