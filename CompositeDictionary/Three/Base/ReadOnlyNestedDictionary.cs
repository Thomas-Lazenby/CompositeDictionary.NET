using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDictionary
{
    public class ReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
    {
        private readonly BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> _nestedDictionary;

        public ReadOnlyNestedDictionary(BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> nestedDictionary)
        {
            _nestedDictionary = nestedDictionary ?? throw new ArgumentNullException(nameof(nestedDictionary));
        }

        public IEnumerable<TPrimaryKey> GetPrimaryKeys() => _nestedDictionary.GetPrimaryKeys();
        public IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey) => _nestedDictionary.GetSecondaryKeys(primaryKey);
        public IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _nestedDictionary.GetThirdKeys(primaryKey, secondaryKey);
        public TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey] => _nestedDictionary[primaryKey, secondaryKey, thirdKey];
        public bool ContainsPrimary(TPrimaryKey primaryKey) => _nestedDictionary.ContainsPrimary(primaryKey);
        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _nestedDictionary.ContainsSecondary(primaryKey, secondaryKey);
        public bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey) => _nestedDictionary.ContainsThirdKey(primaryKey, secondaryKey, thirdKey);
        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, out TValue value) => _nestedDictionary.TryGetValue(primaryKey, secondaryKey, thirdKey, out value);
        public int Count => _nestedDictionary.Count;
        public bool IsEmpty() => _nestedDictionary.IsEmpty();
    }
}

