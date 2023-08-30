using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDictionary
{
    public class ReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
    {
        private readonly ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> _compositeDictionary;

        public ReadOnlyCompositeDictionary(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> compositeDictionary)
        {
            _compositeDictionary = compositeDictionary ?? throw new ArgumentNullException(nameof(compositeDictionary));
        }

        public IEnumerable<TPrimaryKey> GetPrimaryKeys() => _compositeDictionary.GetPrimaryKeys();
        public IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey) => _compositeDictionary.GetSecondaryKeys(primaryKey);
        public IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _compositeDictionary.GetThirdKeys(primaryKey, secondaryKey);
        public TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey] => _compositeDictionary[primaryKey, secondaryKey, thirdKey];
        public bool ContainsPrimary(TPrimaryKey primaryKey) => _compositeDictionary.ContainsPrimary(primaryKey);
        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _compositeDictionary.ContainsSecondary(primaryKey, secondaryKey);
        public bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey) => _compositeDictionary.ContainsThirdKey(primaryKey, secondaryKey, thirdKey);
        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, out TValue value) => _compositeDictionary.TryGetValue(primaryKey, secondaryKey, thirdKey, out value);
        public int Count => _compositeDictionary.Count;
        public bool IsEmpty() => _compositeDictionary.IsEmpty();
    }
}

