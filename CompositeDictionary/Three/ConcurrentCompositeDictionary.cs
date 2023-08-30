using System.Collections.Concurrent;

namespace CompositeDictionary
{
    public class ConcurrentCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
    {
        protected override IDictionary<TThirdKey, TValue> CreateInnerDictionary()
        {
            return new ConcurrentDictionary<TThirdKey, TValue>();
        }

        protected override IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>> CreateMiddleDictionary()
        {
            return new ConcurrentDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>> CreateOuterDictionary()
        {
            return new ConcurrentDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>>();
        }
    }
}
