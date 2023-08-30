using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public class ReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TValue>
       : IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TValue>
       where TPrimaryKey : notnull
       where TSecondaryKey : notnull
    {
        private readonly BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> _baseNestedDictionary;

        public ReadOnlyNestedDictionary(BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> baseNestedDictionary)
        {
            _baseNestedDictionary = baseNestedDictionary;
        }

        public IEnumerable<TPrimaryKey> GetPrimaryKeys() => _baseNestedDictionary.GetPrimaryKeys();

        public IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey) => _baseNestedDictionary.GetSecondaryKeys(primaryKey);

        public bool ContainsPrimary(TPrimaryKey primaryKey) => _baseNestedDictionary.ContainsPrimary(primaryKey);

        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _baseNestedDictionary.ContainsSecondary(primaryKey, secondaryKey);

        public IEnumerable<TValue> GetValuesByPrimary(TPrimaryKey primaryKey) => _baseNestedDictionary.GetValuesByPrimary(primaryKey);

        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, out TValue value) => _baseNestedDictionary.TryGetValue(primaryKey, secondaryKey, out value);

        public int Count => _baseNestedDictionary.Count;

        public bool IsEmpty() => _baseNestedDictionary.IsEmpty();
    }
}
