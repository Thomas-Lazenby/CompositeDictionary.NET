using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDictionary
{
    public abstract class BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> : IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>, ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
        where TFourthKey : notnull
    {
        #region Fields and Constructor

        protected IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>> _data;

        public BaseCompositeDictionary()
        {
            _data = CreateOuterDictionary();
        }

        #endregion

        #region Abstract Factory Methods

        protected abstract IDictionary<TPrimaryKey, IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>>> CreateOuterDictionary();
        protected abstract IDictionary<TSecondaryKey, IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>>> CreateSecondDictionary();
        protected abstract IDictionary<TThirdKey, IDictionary<TFourthKey, TValue>> CreateThirdDictionary();
        protected abstract IDictionary<TFourthKey, TValue> CreateInnerDictionary();

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


        public IEnumerable<TFourthKey> GetFourthKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey)
        {
            if (_data.TryGetValue(primaryKey, out var secondDict) && secondDict.TryGetValue(secondaryKey, out var thirdDict) && thirdDict.TryGetValue(thirdKey, out var fourthDict))
            {
                return fourthDict.Keys;
            }
            throw new KeyNotFoundException($"The combination of primary key '{primaryKey}', secondary key '{secondaryKey}', and third key '{thirdKey}' was not found.");
        }


        #endregion

        #region Indexer

        public TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey]
        {
            get => _data[primaryKey][secondaryKey][thirdKey][fourthKey];
            set
            {
                if (!_data.ContainsKey(primaryKey))
                    _data[primaryKey] = CreateSecondDictionary();
                if (!_data[primaryKey].ContainsKey(secondaryKey))
                    _data[primaryKey][secondaryKey] = CreateThirdDictionary();
                if (!_data[primaryKey][secondaryKey].ContainsKey(thirdKey))
                    _data[primaryKey][secondaryKey][thirdKey] = CreateInnerDictionary();
                _data[primaryKey][secondaryKey][thirdKey][fourthKey] = value;
            }
        }

        #endregion

        #region Basic Operations

        public bool ContainsPrimary(TPrimaryKey primaryKey) => _data.ContainsKey(primaryKey);

        public bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
            => _data.TryGetValue(primaryKey, out var secondDict) && secondDict.ContainsKey(secondaryKey);

        public bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey)
            => _data.TryGetValue(primaryKey, out var secondDict) && secondDict.TryGetValue(secondaryKey, out var thirdDict) && thirdDict.ContainsKey(thirdKey);

        public bool ContainsFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey)
            => _data.TryGetValue(primaryKey, out var secondDict) && secondDict.TryGetValue(secondaryKey, out var thirdDict) && thirdDict.TryGetValue(thirdKey, out var fourthDict) && fourthDict.ContainsKey(fourthKey);

        public bool RemovePrimary(TPrimaryKey primaryKey) => _data.Remove(primaryKey);

        public bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey)
        {
            if (_data.TryGetValue(primaryKey, out var secondDict))
            {
                return secondDict.Remove(secondaryKey);
            }
            return false;
        }

        public bool RemoveThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey)
        {
            if (_data.TryGetValue(primaryKey, out var secondDict) && secondDict.TryGetValue(secondaryKey, out var thirdDict))
            {
                return thirdDict.Remove(thirdKey);
            }
            return false;
        }

        public bool RemoveFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey)
        {
            if (_data.TryGetValue(primaryKey, out var secondDict) && secondDict.TryGetValue(secondaryKey, out var thirdDict) && thirdDict.TryGetValue(thirdKey, out var fourthDict))
            {
                return fourthDict.Remove(fourthKey);
            }
            return false;
        }

        public IEnumerable<TValue> GetValuesByPrimarySecondAndThird(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey)
        {
            if (_data.TryGetValue(primaryKey, out var secondDict) && secondDict.TryGetValue(secondaryKey, out var thirdDict) && thirdDict.TryGetValue(thirdKey, out var fourthDict))
            {
                return fourthDict.Values;
            }
            return Enumerable.Empty<TValue>();
        }

        public void Clear() => _data.Clear();

        public int Count => _data.Sum(kvp => kvp.Value.Sum(secondKvp => secondKvp.Value.Sum(thirdKvp => thirdKvp.Value.Count)));

        public bool IsEmpty() => !_data.Any();

        #endregion

        #region Advanced Operations

        public void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> other)
        {
            foreach (var primaryKey in other.GetPrimaryKeys())
            {
                if (!_data.ContainsKey(primaryKey))
                {
                    _data[primaryKey] = CreateSecondDictionary();
                }

                foreach (var secondaryKey in other.GetSecondaryKeys(primaryKey))
                {
                    if (!_data[primaryKey].ContainsKey(secondaryKey))
                    {
                        _data[primaryKey][secondaryKey] = CreateThirdDictionary();
                    }

                    foreach (var thirdKey in other.GetThirdKeys(primaryKey, secondaryKey))
                    {
                        if (!_data[primaryKey][secondaryKey].ContainsKey(thirdKey))
                        {
                            _data[primaryKey][secondaryKey][thirdKey] = CreateInnerDictionary();
                        }

                        foreach (var fourthKey in other.GetFourthKeys(primaryKey, secondaryKey, thirdKey))
                        {
                            if (other.TryGetValue(primaryKey, secondaryKey, thirdKey, fourthKey, out TValue value))
                            {
                                _data[primaryKey][secondaryKey][thirdKey][fourthKey] = value;
                            }
                        }
                    }
                }
            }
        }


        public bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey, out TValue value)
        {
            if (_data.TryGetValue(primaryKey, out var secondDict) && secondDict.TryGetValue(secondaryKey, out var thirdDict) && thirdDict.TryGetValue(thirdKey, out var fourthDict) && fourthDict.TryGetValue(fourthKey, out value!) )
            {
                return true;
            }
            value = default!;
            return false;
        }



        #endregion
    }
}
