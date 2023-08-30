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

        public static IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TValue> AsReadOnly<TPrimaryKey, TSecondaryKey, TValue>(this BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TValue> nestedDictionary)
            where TPrimaryKey : notnull
            where TSecondaryKey : notnull
        {
            return new ReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TValue>(nestedDictionary);
        }

        public static IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> AsReadOnly<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>(this BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue> nestedDictionary)
            where TPrimaryKey : notnull
            where TSecondaryKey : notnull
            where TThirdKey : notnull
        {
            return new ReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TValue>(nestedDictionary);
        }

        public static IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> AsReadOnly<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>(this BaseCompositeDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue> nestedDictionary)
            where TPrimaryKey : notnull
            where TSecondaryKey : notnull
            where TThirdKey : notnull
            where TFourthKey : notnull
        {
            return new ReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>(nestedDictionary);
        }
    }
}
