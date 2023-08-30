using CompositeDictionary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDictionary
{

    public abstract class BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> : IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TValue>, ICompositeDictionary<TPrimaryKey, TSecondaryKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
    {
        #region Fields and Constructor

        protected IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, TValue>> _data;

        public BaseCompositeDictionary()
        {
            _data = CreateOuterDictionary();
        }

        #endregion

        #region Abstract Factory Methods

        protected abstract IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, TValue>> CreateOuterDictionary();
        protected abstract IDictionary<TSecondaryKey, TValue> CreateInnerDictionary();

        #endregion

        #region Key Retrieval

        public IEnumerable<TPrimaryKey> GetPrimaryKeys() => _data.Keys;

        public IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey)
        {
            if (_data.TryGetValue(primaryKey, out var middleDict))
            {
                return middleDict.Keys;
            }
            throw new KeyNotFoundException($"The primary key '{primaryKey}' was not found.");
        }

        #endregion

        #region Indexer

        public TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey]
        {
            get => _data[primaryKey][secondaryKey];
            set
            {
                if (!_data.ContainsKey(primaryKey))
                    _data[primaryKey] = CreateInnerDictionary();
                _data[primaryKey][secondaryKey] = value;
            }
        }

        #endregion

        #region Basic Operations

        public bool ContainsPrimary(TPrimaryKey primaryKey) => _data.ContainsKey(primaryKey);

        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
            => _data.TryGetValue(primaryKey, out var innerDict) && innerDict.ContainsKey(secondaryKey);

        public bool RemovePrimary(TPrimaryKey primaryKey) => _data.Remove(primaryKey);

        public bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
        {
            if (_data.TryGetValue(primaryKey, out var innerDict))
            {
                return innerDict.Remove(secondaryKey);
            }
            return false;
        }

        public IEnumerable<TValue> GetValuesByPrimary(TPrimaryKey primaryKey)
        {
            if (_data.TryGetValue(primaryKey, out var innerDict))
            {
                return innerDict.Values;
            }
            return Enumerable.Empty<TValue>();
        }

        public void Clear() => _data.Clear();

        public int Count => _data.Sum(kvp => kvp.Value.Count);

        public bool IsEmpty() => !_data.Any();

        #endregion

        #region Advanced Operations

        public void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> other)
        {
            foreach (var primaryKey in other.GetPrimaryKeys())
            {
                if (!_data.ContainsKey(primaryKey))
                {
                    _data[primaryKey] = new Dictionary<TSecondaryKey, TValue>();
                }

                foreach (var secondaryKey in other.GetSecondaryKeys(primaryKey))
                {
                    if (other.TryGetValue(primaryKey, secondaryKey, out TValue value))
                    {
                        _data[primaryKey][secondaryKey] = value;
                    }
                }
            }
        }


        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, out TValue value)
        {
            if (_data.TryGetValue(primaryKey, out var innerDict) && innerDict.TryGetValue(secondaryKey, out value!))
            {
                return true;
            }
            value = default!;
            return false;
        }



        #endregion
    }
}
