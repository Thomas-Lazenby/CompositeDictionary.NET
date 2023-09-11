using CompositeDictionary;
using System.Collections.Generic;
using Xunit;

namespace CompositeDictionary
{
    public class NonAsyncCompositeDictionaryTypesProvider : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // 2-key dictionaries
            yield return new object[] { new CompositeDictionary<string, string, int>(), "CompositeDictionary" };
            yield return new object[] { new SortedCompositeDictionary<string, string, int>(), "SortedCompositeDictionary" };
            yield return new object[] { new ConcurrentCompositeDictionary<string, string, int>(), "ConcurrentCompositeDictionary" };

            // 3-key dictionaries
            yield return new object[] { new CompositeDictionary<string, string, string, int>(), "CompositeDictionary3Key" };
            yield return new object[] { new SortedCompositeDictionary<string, string, string, int>(), "SortedCompositeDictionary3Key" };
            yield return new object[] { new ConcurrentCompositeDictionary<string, string, string, int>(), "ConcurrentCompositeDictionary3Key" };

            // 4-key dictionaries
            yield return new object[] { new CompositeDictionary<string, string, string, string, int>(), "CompositeDictionary4Key" };
            yield return new object[] { new SortedCompositeDictionary<string, string, string, string, int>(), "SortedCompositeDictionary4Key" };
            yield return new object[] { new ConcurrentCompositeDictionary<string, string, string, string, int>(), "ConcurrentCompositeDictionary4Key" };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

