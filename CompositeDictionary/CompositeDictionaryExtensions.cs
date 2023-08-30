using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDictionary
{
    public static class CompositeDictionaryExtensions
    {

        public static IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> AsReadOnly<TPrimaryKey, TSecondaryKey, TValue>(this ICompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> compositeDictionary)
            where TPrimaryKey : notnull
            where TSecondaryKey : notnull
        {
            return new ReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue>(compositeDictionary);
        }

        public static IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> AsReadOnly<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>(this ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> compositeDictionary)
            where TPrimaryKey : notnull
            where TSecondaryKey : notnull
            where TThirdKey : notnull
        {
            return new ReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>(compositeDictionary);
        }

        public static IReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> AsReadOnly<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>(this ICompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> compositeDictionary)
            where TPrimaryKey : notnull
            where TSecondaryKey : notnull
            where TThirdKey : notnull
            where TFourthKey : notnull
        {
            return new ReadOnlyCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>(compositeDictionary);
        }
    }
}
