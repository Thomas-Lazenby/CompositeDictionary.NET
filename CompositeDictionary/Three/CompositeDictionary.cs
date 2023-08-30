namespace CompositeDictionary
{
    public class CompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
    {
        protected override IDictionary<TThirdKey, TValue> CreateInnerDictionary()
        {
            return new Dictionary<TThirdKey, TValue>();
        }

        protected override IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>> CreateMiddleDictionary()
        {
            return new Dictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>> CreateOuterDictionary()
        {
            return new Dictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>>();
        }
    }
}
