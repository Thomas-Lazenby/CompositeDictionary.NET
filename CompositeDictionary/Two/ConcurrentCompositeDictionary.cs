using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public class ConcurrentCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
    {
        protected override IDictionary<TSecondaryKey, TValue> CreateInnerDictionary()
        {
            return new ConcurrentDictionary<TSecondaryKey, TValue>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, TValue>> CreateOuterDictionary()
        {
            return new ConcurrentDictionary<TPrimaryKey, IDictionary<TSecondaryKey, TValue>>();
        }
    }
}
