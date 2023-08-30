namespace CompositeDictionary
{
    public class SortedCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>
        where TPrimaryKey : notnull, IComparable<TPrimaryKey>
        where TSecondaryKey : notnull, IComparable<TSecondaryKey>
        where TThirdKey : notnull, IComparable<TThirdKey>
    {
        protected override IDictionary<TThirdKey, TValue> CreateInnerDictionary()
        {
            return new SortedDictionary<TThirdKey, TValue>();
        }

        protected override IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>> CreateMiddleDictionary()
        {
            return new SortedDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>> CreateOuterDictionary()
        {
            return new SortedDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>>();
        }
    }
}
