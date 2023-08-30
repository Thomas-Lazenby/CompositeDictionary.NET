using System.Collections.Generic;

namespace CompositeDictionary
{
    public class SortedCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull, IComparable<TPrimaryKey>
        where TSecondaryKey : notnull, IComparable<TSecondaryKey>
        where TThirdKey : notnull, IComparable<TThirdKey>
        where TFourthKey : notnull, IComparable<TFourthKey>
    {
        protected override IDictionary<TFourthKey, TValue> CreateInnerDictionary()
        {
            return new SortedDictionary<TFourthKey, TValue>();
        }

        protected override IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>> CreateThirdDictionary()
        {
            return new SortedDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>();
        }

        protected override IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>> CreateSecondDictionary()
        {
            return new SortedDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>> CreateOuterDictionary()
        {
            return new SortedDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>>();
        }
    }
}
