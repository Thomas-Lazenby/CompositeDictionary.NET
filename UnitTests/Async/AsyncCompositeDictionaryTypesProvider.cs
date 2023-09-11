using System.Collections;
using System.Collections.Generic;
using CompositeDictionary;

namespace CompositeDictionary.UnitTests.Async
{
    public class AsyncCompositeDictionaryTypesProvider : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new ConcurrentCompositeDictionary<string, string, int>(), "ConcurrentCompositeDictionary" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
