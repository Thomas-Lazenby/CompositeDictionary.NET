using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public interface ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> : IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>, ICompositeDictionary
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
    {
        new TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey] { get; set; }

        bool RemovePrimary(TPrimaryKey primaryKey);

        bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        bool RemoveThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);


        void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> other);

        
    }

}
