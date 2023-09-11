using CompositeDictionary;
using System.Collections;

namespace CompositeDictionary.UnitTests
{
    public class NonAsyncTwoCompositeDictionaryTypesProvider : IEnumerable<object[]>
    {
        private readonly List<object[]> singleDictionaries = new NonAsyncCompositeDictionaryTypesProvider().ToList();

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var dict1Data in singleDictionaries)
            {
                foreach (var dict2Data in singleDictionaries)
                {
                    var dict1 = dict1Data[0];
                    var dict2 = dict2Data[0];
                    var name1 = dict1Data[1] as string;
                    var name2 = dict2Data[1] as string;

                    // Ensure the dictionaries have the same depth
                    if (dict1.GetType().GetGenericArguments().Length == dict2.GetType().GetGenericArguments().Length)
                    {
                        yield return new object[] { dict1, dict2, $"{name1}-{name2}" };
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
