using System.Collections.Concurrent;

namespace CompositeDictionary
{
    public class ConcurrentCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
        where TFourthKey : notnull
    {
        protected override IDictionary<TFourthKey, TValue> CreateInnerDictionary()
        {
            return new ConcurrentDictionary<TFourthKey, TValue>();
        }

        protected override IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>> CreateThirdDictionary()
        {
            return new ConcurrentDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>();
        }

        protected override IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>> CreateSecondDictionary()
        {
            return new ConcurrentDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>> CreateOuterDictionary()
        {
            return new ConcurrentDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>>();
        }
    }
}
