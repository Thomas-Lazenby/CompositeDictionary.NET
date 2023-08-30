

namespace CompositeDictionary
{
    public class CompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> : BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
        where TFourthKey : notnull
    {
        protected override IDictionary<TFourthKey, TValue> CreateInnerDictionary()
        {
            return new Dictionary<TFourthKey, TValue>();
        }

        protected override IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>> CreateThirdDictionary()
        {
            return new Dictionary<TThirdKey, IDictionary<TFourthKey, TValue>>();
        }

        protected override IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>> CreateSecondDictionary()
        {
            return new Dictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>();
        }

        protected override IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>> CreateOuterDictionary()
        {
            return new Dictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>>();
        }
    }
}
