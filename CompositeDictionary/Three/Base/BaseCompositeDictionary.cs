using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDictionary
{
    public abstract class BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : ICompositeDictionary, IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>, ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
    {
        #region Fields and Constructor

        protected IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>> _data;

        public BaseCompositeDictionary()
        {
            _data = CreateOuterDictionary();
        }

        #endregion

        #region Abstract Factory Methods

        protected abstract IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>>> CreateOuterDictionary();
        protected abstract IDictionary<TSecondaryKey, IDictionary<TThirdKey, TValue>> CreateMiddleDictionary();
        protected abstract IDictionary<TThirdKey, TValue> CreateInnerDictionary();

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

        public IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
        {
            if (_data.TryGetValue(primaryKey, out var middleDict) && middleDict.TryGetValue(secondaryKey, out var innerDict))
            {
                return innerDict.Keys;
            }
            throw new KeyNotFoundException($"The combination of primary key '{primaryKey}' and secondary key '{secondaryKey}' was not found.");
        }


        #endregion

        #region Indexer

        public virtual TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey]
        {
            get => _data[primaryKey][secondaryKey][thirdKey];
            set
            {
                if (!_data.ContainsKey(primaryKey))
                    _data[primaryKey] = CreateMiddleDictionary();
                if (!_data[primaryKey].ContainsKey(secondaryKey))
                    _data[primaryKey][secondaryKey] = CreateInnerDictionary();
                _data[primaryKey][secondaryKey][thirdKey] = value;
            }
        }

        #endregion

        #region Basic Operations

        public bool ContainsPrimary(TPrimaryKey primaryKey) => _data.ContainsKey(primaryKey);

        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
            => _data.TryGetValue(primaryKey, out var middleDict) && middleDict.ContainsKey(secondaryKey);

        public bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey)
            => _data.TryGetValue(primaryKey, out var middleDict) && middleDict.TryGetValue(secondaryKey, out var innerDict) && innerDict.ContainsKey(thirdKey);

        public bool RemovePrimary(TPrimaryKey primaryKey) => _data.Remove(primaryKey);

        public bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
        {
            if (_data.TryGetValue(primaryKey, out var middleDict))
            {
                return middleDict.Remove(secondaryKey);
            }
            return false;
        }

        public bool RemoveThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey)
        {
            if (_data.TryGetValue(primaryKey, out var middleDict) && middleDict.TryGetValue(secondaryKey, out var innerDict))
            {
                return innerDict.Remove(thirdKey);
            }
            return false;
        }

        public IEnumerable<TValue> GetValuesByPrimaryAndSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
        {
            if (_data.TryGetValue(primaryKey, out var middleDict) && middleDict.TryGetValue(secondaryKey, out var innerDict))
            {
                return innerDict.Values;
            }
            return Enumerable.Empty<TValue>();
        }

        public void Clear() => _data.Clear();

        // TODO: Count tracking instead ? (Concurrent consideration etc)
        public int Count => _data.Sum(kvp => kvp.Value.Sum(innerKvp => innerKvp.Value.Count));

        public bool IsEmpty() => !_data.Any();

        #endregion

        #region Advanced Operations

        public void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> other)
        {
            foreach (var primaryKey in other.GetPrimaryKeys())
            {
                if (!_data.ContainsKey(primaryKey))
                {
                    _data[primaryKey] = CreateMiddleDictionary();
                }

                foreach (var secondaryKey in other.GetSecondaryKeys(primaryKey))
                {
                    if (!_data[primaryKey].ContainsKey(secondaryKey))
                    {
                        _data[primaryKey][secondaryKey] = CreateInnerDictionary();
                    }

                    foreach (var thirdKey in other.GetThirdKeys(primaryKey, secondaryKey))
                    {
                        if (other.TryGetValue(primaryKey, secondaryKey, thirdKey, out TValue value))
                        {
                            _data[primaryKey][secondaryKey][thirdKey] = value;
                        }
                    }
                }
            }
        }



        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, out TValue value)
        {
            if (_data.TryGetValue(primaryKey, out var middleDict) && middleDict.TryGetValue(secondaryKey, out var innerDict) && innerDict.TryGetValue(thirdKey, out value!))
            {
                return true;
            }
            value = default!;
            return false;
        }



        #endregion
    }
}
