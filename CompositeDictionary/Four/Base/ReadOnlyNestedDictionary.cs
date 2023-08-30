

namespace CompositeDictionary
{
    public class ReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        : IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
        where TFourthKey : notnull
    {
        private readonly BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> _nestedDictionary;

        public ReadOnlyNestedDictionary(BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> nestedDictionary)
        {
            _nestedDictionary = nestedDictionary ?? throw new ArgumentNullException(nameof(nestedDictionary));
        }

        public IEnumerable<TPrimaryKey> GetPrimaryKeys() => _nestedDictionary.GetPrimaryKeys();
        public IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey) => _nestedDictionary.GetSecondaryKeys(primaryKey);
        public IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _nestedDictionary.GetThirdKeys(primaryKey, secondaryKey);
        public IEnumerable<TFourthKey> GetFourthKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey) => _nestedDictionary.GetFourthKeys(primaryKey, secondaryKey, thirdKey);
        public TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey] => _nestedDictionary[primaryKey, secondaryKey, thirdKey, fourthKey];
        public bool ContainsPrimary(TPrimaryKey primaryKey) => _nestedDictionary.ContainsPrimary(primaryKey);
        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _nestedDictionary.ContainsSecondary(primaryKey, secondaryKey);
        public bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey) => _nestedDictionary.ContainsThirdKey(primaryKey, secondaryKey, thirdKey);
        public bool ContainsFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey) => _nestedDictionary.ContainsFourthKey(primaryKey, secondaryKey, thirdKey, fourthKey);
        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey, out TValue value) => _nestedDictionary.TryGetValue(primaryKey, secondaryKey, thirdKey, fourthKey, out value);
        public int Count => _nestedDictionary.Count;
        public bool IsEmpty() => _nestedDictionary.IsEmpty();
    }
}
