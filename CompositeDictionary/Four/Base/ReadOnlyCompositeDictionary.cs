

namespace CompositeDictionary
{
    public class ReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        : IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
        where TFourthKey : notnull
    {
        private readonly ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> _compositeDictionary;

        public ReadOnlyCompositeDictionary(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> compositeDictionary)
        {
            _compositeDictionary = compositeDictionary ?? throw new ArgumentNullException(nameof(compositeDictionary));
        }

        public IEnumerable<TPrimaryKey> GetPrimaryKeys() => _compositeDictionary.GetPrimaryKeys();
        public IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey) => _compositeDictionary.GetSecondaryKeys(primaryKey);
        public IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _compositeDictionary.GetThirdKeys(primaryKey, secondaryKey);
        public IEnumerable<TFourthKey> GetFourthKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey) => _compositeDictionary.GetFourthKeys(primaryKey, secondaryKey, thirdKey);
        public TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey] => _compositeDictionary[primaryKey, secondaryKey, thirdKey, fourthKey];
        public bool ContainsPrimary(TPrimaryKey primaryKey) => _compositeDictionary.ContainsPrimary(primaryKey);
        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _compositeDictionary.ContainsSecondary(primaryKey, secondaryKey);
        public bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey) => _compositeDictionary.ContainsThirdKey(primaryKey, secondaryKey, thirdKey);
        public bool ContainsFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey) => _compositeDictionary.ContainsFourthKey(primaryKey, secondaryKey, thirdKey, fourthKey);
        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey, out TValue value) => _compositeDictionary.TryGetValue(primaryKey, secondaryKey, thirdKey, fourthKey, out value);
        public int Count => _compositeDictionary.Count;
        public bool IsEmpty() => _compositeDictionary.IsEmpty();

        public IEnumerable<TValue> GetValuesByPrimarySecondAndThird(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey)
            => _compositeDictionary.GetValuesByPrimarySecondAndThird(primaryKey, secondaryKey, thirdKey);
    }
}
