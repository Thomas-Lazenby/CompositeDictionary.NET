using CompositeDictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CompositeDictionary.UnitTests
{
    internal static class CompositeDictionaryHelper
    {
        public static void CreateData(ICompositeDictionary dict, int primaryAmount = 16, int secondaryAmount = 8, int thirdAmount = 4, int fourthAmount = 2)
        {
            if (IsTypeOfCompositeDictionary2Key(dict, out var composite2Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        composite2Key[$"Key1-{i}", $"Key2-{j}"] = j;
                    }
                }
            }
            else if (IsTypeOfCompositeDictionary3Key(dict, out var composite3Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            composite3Key[$"Key1-{i}", $"Key2-{j}", $"Key3-{k}"] = k;
                        }
                    }
                }
            }
            else if (IsTypeOfCompositeDictionary4Key(dict, out var composite4Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            for (int l = 1; l <= fourthAmount; l++)
                            {
                                composite4Key[$"Key1-{i}", $"Key2-{j}", $"Key3-{k}", $"Key4-{l}"] = l;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Unsupported dictionary type", nameof(dict));
            }
        }




        public static IEnumerable<T> GetAllPrimaryKeys<T>(ICompositeDictionary dict)
        {
            if (IsTypeOfCompositeDictionary2Key(dict, out var composite2Key))
            {
                return composite2Key.GetPrimaryKeys().Cast<T>();
            }
            else if (IsTypeOfCompositeDictionary3Key(dict, out var composite3Key))
            {
                return composite3Key.GetPrimaryKeys().Cast<T>();
            }
            else if (IsTypeOfCompositeDictionary4Key(dict, out var composite4Key))
            {
                return composite4Key.GetPrimaryKeys().Cast<T>();
            }
            else
            {
                throw new ArgumentException("Unsupported dictionary type", nameof(dict));
            }
        }

        public static void AssertValuePresence(ICompositeDictionary dict, int count)
        {
            if (IsTypeOfCompositeDictionary2Key(dict, out var composite2Key))
            {
                for (int i = 0; i < count; i++)
                {
                    bool keyExists = composite2Key.ContainsSecondary($"Key1-{i}", $"Key2-{i}");
                    Assert.True(keyExists, $"Key1-{i}, Key2-{i} not found in Composite Dictionary with 2 Keys");

                    int value = composite2Key[$"Key1-{i}", $"Key2-{i}"];
                    Assert.Equal(i, value);
                }
            }
            else if (IsTypeOfCompositeDictionary3Key(dict, out var composite3Key))
            {
                for (int i = 0; i < count; i++)
                {
                    bool keyExists = composite3Key.ContainsThirdKey($"Key1-{i}", $"Key2-{i}", $"Key3-{i}");
                    Assert.True(keyExists, $"Key1-{i}, Key2-{i}, Key3-{i} not found in Composite Dictionary with 3 Keys");

                    int value = composite3Key[$"Key1-{i}", $"Key2-{i}", $"Key3-{i}"];
                    Assert.Equal(i, value);
                }
            }
            else if (IsTypeOfCompositeDictionary4Key(dict, out var composite4Key))
            {
                for (int i = 0; i < count; i++)
                {
                    bool keyExists = composite4Key.ContainsFourthKey($"Key1-{i}", $"Key2-{i}", $"Key3-{i}", $"Key4-{i}");
                    Assert.True(keyExists, $"Key1-{i}, Key2-{i}, Key3-{i}, Key4-{i} not found in Composite Dictionary with 4 Keys");

                    int value = composite4Key[$"Key1-{i}", $"Key2-{i}", $"Key3-{i}", $"Key4-{i}"];
                    Assert.Equal(i, value);
                }
            }
            else
            {
                throw new ArgumentException("Unsupported dictionary type", nameof(dict));
            }
        }

        public static void AssertAllPrimaryKeysPresent(ICompositeDictionary dict, int count)
        {
            if (IsTypeOfCompositeDictionary2Key(dict, out var composite2Key))
            {
                var primaryKeys = composite2Key.GetPrimaryKeys().ToList();
                for (int i = 0; i < count; i++)
                {
                    Assert.Contains($"Key1-{i}", primaryKeys);
                }
            }
            else if (IsTypeOfCompositeDictionary3Key(dict, out var composite3Key))
            {
                var primaryKeys = composite3Key.GetPrimaryKeys().ToList();
                for (int i = 0; i < count; i++)
                {
                    Assert.Contains($"Key1-{i}", primaryKeys);
                }
            }
            else if (IsTypeOfCompositeDictionary4Key(dict, out var composite4Key))
            {
                var primaryKeys = composite4Key.GetPrimaryKeys().ToList();
                for (int i = 0; i < count; i++)
                {
                    Assert.Contains($"Key1-{i}", primaryKeys);
                }
            }
            else
            {
                throw new ArgumentException("Unsupported dictionary type", nameof(dict));
            }
        }


        public static bool IsTypeOfCompositeDictionary2Key(ICompositeDictionary dict, out ICompositeDictionary<string, string, int> composite2Key)
        {
            if (dict is ICompositeDictionary<string, string, int> nd)
            {
                composite2Key = nd;
                return true;
            }
            composite2Key = null;
            return false;
        }

        public static bool IsTypeOfCompositeDictionary3Key(ICompositeDictionary dict, out ICompositeDictionary<string, string, string, int> composite3Key)
        {
            if (dict is ICompositeDictionary<string, string, string, int> nd)
            {
                composite3Key = nd;
                return true;
            }
            composite3Key = null;
            return false;
        }

        public static bool IsTypeOfCompositeDictionary4Key(ICompositeDictionary dict, out ICompositeDictionary<string, string, string, string, int> composite4Key)
        {
            if (dict is ICompositeDictionary<string, string, string, string, int> nd)
            {
                composite4Key = nd;
                return true;
            }
            composite4Key = null;
            return false;
        }


    }
}
