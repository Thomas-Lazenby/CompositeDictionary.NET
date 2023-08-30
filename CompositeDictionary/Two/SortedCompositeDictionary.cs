using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public class SortedCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
    {
        protected override IDictionary<TSecondaryKey, TValue> CreateInnerDictionary()
        {
            return new SortedDictionary<TSecondaryKey, TValue>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, TValue>> CreateOuterDictionary()
        {
            return new SortedDictionary<TPrimaryKey, IDictionary<TSecondaryKey, TValue>>();
        }
    }
}
