using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public interface ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> : ICompositeDictionary, IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
        where TFourthKey : notnull
    {
        new TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey] { get; set; }

        bool RemovePrimary(TPrimaryKey primaryKey);

        bool RemoveSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);

        bool RemoveThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);

        bool RemoveFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey);


        void Merge(ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> other);

    }

}
