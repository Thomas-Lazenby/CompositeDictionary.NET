using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public interface ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : ICompositeDictionary
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
    {
        TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey] { get; set; }

        IEnumerable<TPrimaryKey> GetPrimaryKeys();

        IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey);

        IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        bool ContainsPrimary(TPrimaryKey primaryKey);

        bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);

        bool RemovePrimary(TPrimaryKey primaryKey);

        bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        bool RemoveThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);

        IEnumerable<TValue> GetValuesByPrimaryAndSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> other);

        /// <summary>
        /// Attempts to retrieve a value from the nested dictionaries based on the provided keys.
        /// </summary>
        /// <param name="primaryKey">The primary key to search in the main dictionary.</param>
        /// <param name="secondaryKey">The secondary key to search in the sub-dictionary associated with the primary key.</param>
        /// <param name="thirdKey">The third key to search in the sub-dictionary associated with the secondary key.</param>
        /// <param name="value">The retrieved value if found. If not found, this will be set to the default value of <typeparamref name="TValue"/>. 
        /// Note: For reference types, this could be null.</param>
        /// <returns>True if the value was found using the provided keys. False otherwise.</returns>
        bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, out TValue value);
    }

}
