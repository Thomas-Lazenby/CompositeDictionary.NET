using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public interface ICompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> : ICompositeDictionary, IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
    {
        new TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey] { get; set; }


        bool RemovePrimary(TPrimaryKey primaryKey);

        bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> other);



    }

}
