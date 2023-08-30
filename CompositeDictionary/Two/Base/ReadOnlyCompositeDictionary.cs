using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public class ReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue>
       : IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue>
       where TPrimaryKey : notnull
       where TSecondaryKey : notnull
    {
        private readonly ICompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> _baseCompositeDictionary;

        public ReadOnlyCompositeDictionary(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> baseCompositeDictionary)
        {
            _baseCompositeDictionary = baseCompositeDictionary;
        }

        public IEnumerable<TPrimaryKey> GetPrimaryKeys() => _baseCompositeDictionary.GetPrimaryKeys();

        public IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey) => _baseCompositeDictionary.GetSecondaryKeys(primaryKey);

        public bool ContainsPrimary(TPrimaryKey primaryKey) => _baseCompositeDictionary.ContainsPrimary(primaryKey);

        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey) => _baseCompositeDictionary.ContainsSecondary(primaryKey, secondaryKey);

        public IEnumerable<TValue> GetValuesByPrimary(TPrimaryKey primaryKey) => _baseCompositeDictionary.GetValuesByPrimary(primaryKey);

        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, out TValue value) => _baseCompositeDictionary.TryGetValue(primaryKey, secondaryKey, out value);

        public int Count => _baseCompositeDictionary.Count;

        public bool IsEmpty() => _baseCompositeDictionary.IsEmpty();
    }
}
