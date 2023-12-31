﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public interface IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> : IReadOnlyCompositeDictionary
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
    {
        IEnumerable<TPrimaryKey> GetPrimaryKeys();
        IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey);

        TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey] { get; }


        bool ContainsPrimary(TPrimaryKey primaryKey);
        bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);
        IEnumerable<TValue> GetValuesByPrimary(TPrimaryKey primaryKey);

        /// <summary>
        /// Attempts to retrieve a value from the composite dictionaries based on the provided keys.
        /// </summary>
        /// <param name="primaryKey">The primary key to search in the main dictionary.</param>
        /// <param name="secondaryKey">The secondary key to search in the sub-dictionary associated with the primary key.</param>
        /// <param name="value">The retrieved value if found. If not found, this will be set to the default value of <typeparamref name="TValue"/>. 
        /// Note: For reference types, this could be null.</param>
        /// <returns>True if the value was found using the provided keys. False otherwise.</returns>
        bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, out TValue value);
    }
}
