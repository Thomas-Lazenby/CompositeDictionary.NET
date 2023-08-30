using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public interface IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
    {
        IEnumerable<TPrimaryKey> GetPrimaryKeys();
        IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey);
        bool ContainsPrimary(TPrimaryKey primaryKey);
        bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);
        IEnumerable<TValue> GetValuesByPrimary(TPrimaryKey primaryKey);
        bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, out TValue value);
        int Count { get; }
        bool IsEmpty();
    }
}
