using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public interface ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> : ICompositeDictionary
    {
        IEnumerable<TPrimaryKey> GetPrimaryKeys();

        IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey);

        IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        IEnumerable<TFourthKey> GetFourthKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);

        TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey] { get; set; }

        bool ContainsPrimary(TPrimaryKey primaryKey);

        bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);

        bool ContainsFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey);

        bool RemovePrimary(TPrimaryKey primaryKey);

        bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        bool RemoveThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);

        bool RemoveFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey);

        IEnumerable<TValue> GetValuesByPrimarySecondAndThird(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);

        void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> other);


        /// <summary>
        /// Attempts to retrieve a value from the composite dictionaries based on the provided keys.
        /// </summary>
        /// <param name="primaryKey">The primary key to search in the main dictionary.</param>
        /// <param name="secondaryKey">The secondary key to search in the sub-dictionary associated with the primary key.</param>
        /// <param name="thirdKey">The third key to search in the sub-dictionary associated with the secondary key.</param>
        /// <param name="fourthKey">The fourth key to search in the sub-dictionary associated with the third key.</param>
        /// <param name="value">The retrieved value if found. If not found, this will be set to the default value of <typeparamref name="TValue"/>. 
        /// Note: For reference types, this could be null.</param>
        /// <returns>True if the value was found using the provided keys. False otherwise.</returns>
        bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey, out TValue value);
    }

}
