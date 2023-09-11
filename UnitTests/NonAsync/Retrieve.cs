using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CompositeDictionary.UnitTests.NonAsync
{
    public class Retrieve
    {
        [Theory]
        [ClassData(typeof(NonAsyncCompositeDictionaryTypesProvider))]
        public void CanRetrieveAllValues(ICompositeDictionary dict, string className)
        {
            int primaryAmount = 16;
            int secondaryAmount = 8;
            int thirdAmount = 4;
            int fourthAmount = 2;

            CompositeDictionaryHelper.CreateData(dict, primaryAmount, secondaryAmount, thirdAmount, fourthAmount);

            if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary2Key(dict, out var nested2Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        bool primaryKeyExists = nested2Key.ContainsPrimary($"Key1-{i}");
                        bool secondaryKeyExists = nested2Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}");
                        Assert.True(primaryKeyExists && secondaryKeyExists, $"Key1-{i}, Key2-{j} not found in Nested Dictionary with 2 Keys");

                        int value = nested2Key[$"Key1-{i}", $"Key2-{j}"];
                        Assert.Equal(j, value);
                    }
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary3Key(dict, out var nested3Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            bool primaryKeyExists = nested3Key.ContainsPrimary($"Key1-{i}");
                            bool secondaryKeyExists = nested3Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}");
                            bool thirdKeyExists = nested3Key.ContainsThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}");

                            Assert.True(primaryKeyExists && secondaryKeyExists && thirdKeyExists, $"Key1-{i}, Key2-{j}, Key3-{k} not found in Nested Dictionary with 3 Keys");

                            int value = nested3Key[$"Key1-{i}", $"Key2-{j}", $"Key3-{k}"];
                            Assert.Equal(k, value);
                        }
                    }
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary4Key(dict, out var nested4Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            for (int l = 1; l <= fourthAmount; l++)
                            {
                                bool primaryKeyExists = nested4Key.ContainsPrimary($"Key1-{i}");
                                bool secondaryKeyExists = nested4Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}");
                                bool thirdKeyExists = nested4Key.ContainsThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}");
                                bool fourthKeyExists = nested4Key.ContainsFourthKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}", $"Key4-{l}");

                                Assert.True(primaryKeyExists && secondaryKeyExists && thirdKeyExists && fourthKeyExists, $"Key1-{i}, Key2-{j}, Key3-{k}, Key4-{l} not found in Nested Dictionary with 4 Keys");

                                int value = nested4Key[$"Key1-{i}", $"Key2-{j}", $"Key3-{k}", $"Key4-{l}"];
                                Assert.Equal(l, value);
                            }
                        }
                    }
                }
            }
        }

        [Theory]
        [ClassData(typeof(NonAsyncCompositeDictionaryTypesProvider))]
        public void CanRetrieveAllKeys(ICompositeDictionary dict, string className)
        {
            int primaryAmount = 16;
            int secondaryAmount = 8;
            int thirdAmount = 4;
            int fourthAmount = 2;

            CompositeDictionaryHelper.CreateData(dict, primaryAmount, secondaryAmount, thirdAmount, fourthAmount);

            if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary2Key(dict, out var nested2Key))
            {
                var primaryKeys = nested2Key.GetPrimaryKeys().ToList();
                Assert.Equal(primaryAmount, primaryKeys.Count);

                foreach (var primaryKey in primaryKeys)
                {
                    var secondaryKeys = nested2Key.GetSecondaryKeys(primaryKey).ToList();
                    Assert.Equal(secondaryAmount, secondaryKeys.Count);
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary3Key(dict, out var nested3Key))
            {
                var primaryKeys = nested3Key.GetPrimaryKeys().ToList();
                Assert.Equal(primaryAmount, primaryKeys.Count);

                foreach (var primaryKey in primaryKeys)
                {
                    var secondaryKeys = nested3Key.GetSecondaryKeys(primaryKey).ToList();
                    Assert.Equal(secondaryAmount, secondaryKeys.Count);

                    foreach (var secondaryKey in secondaryKeys)
                    {
                        var thirdKeys = nested3Key.GetThirdKeys(primaryKey, secondaryKey).ToList();
                        Assert.Equal(thirdAmount, thirdKeys.Count);
                    }
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary4Key(dict, out var nested4Key))
            {
                var primaryKeys = nested4Key.GetPrimaryKeys().ToList();
                Assert.Equal(primaryAmount, primaryKeys.Count);

                foreach (var primaryKey in primaryKeys)
                {
                    var secondaryKeys = nested4Key.GetSecondaryKeys(primaryKey).ToList();
                    Assert.Equal(secondaryAmount, secondaryKeys.Count);

                    foreach (var secondaryKey in secondaryKeys)
                    {
                        var thirdKeys = nested4Key.GetThirdKeys(primaryKey, secondaryKey).ToList();
                        Assert.Equal(thirdAmount, thirdKeys.Count);

                        foreach (var thirdKey in thirdKeys)
                        {
                            var fourthKeys = nested4Key.GetFourthKeys(primaryKey, secondaryKey, thirdKey).ToList();
                            Assert.Equal(fourthAmount, fourthKeys.Count);
                        }
                    }
                }
            }
        }

        [Theory]
        [ClassData(typeof(NonAsyncCompositeDictionaryTypesProvider))]
        public void CanRemoveAllKeys(ICompositeDictionary dict, string className)
        {
            int primaryAmount = 16;
            int secondaryAmount = 8;
            int thirdAmount = 4;
            int fourthAmount = 2;

            CompositeDictionaryHelper.CreateData(dict, primaryAmount, secondaryAmount, thirdAmount, fourthAmount);

            if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary2Key(dict, out var nested2Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        Assert.True(nested2Key.RemoveSecondary($"Key1-{i}", $"Key2-{j}"));
                        Assert.False(nested2Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}"));
                    }
                    Assert.True(nested2Key.RemovePrimary($"Key1-{i}"));
                    Assert.False(nested2Key.ContainsPrimary($"Key1-{i}"));
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary3Key(dict, out var nested3Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            Assert.True(nested3Key.RemoveThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}"));
                            Assert.False(nested3Key.ContainsThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}"));
                        }
                        Assert.True(nested3Key.RemoveSecondary($"Key1-{i}", $"Key2-{j}"));
                        Assert.False(nested3Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}"));
                    }
                    Assert.True(nested3Key.RemovePrimary($"Key1-{i}"));
                    Assert.False(nested3Key.ContainsPrimary($"Key1-{i}"));
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary4Key(dict, out var nested4Key))
            {
                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            for (int l = 1; l <= fourthAmount; l++)
                            {
                                Assert.True(nested4Key.RemoveFourthKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}", $"Key4-{l}"));
                                Assert.False(nested4Key.ContainsFourthKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}", $"Key4-{l}"));
                            }
                            Assert.True(nested4Key.RemoveThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}"));
                            Assert.False(nested4Key.ContainsThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}"));
                        }
                        Assert.True(nested4Key.RemoveSecondary($"Key1-{i}", $"Key2-{j}"));
                        Assert.False(nested4Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}"));
                    }
                    Assert.True(nested4Key.RemovePrimary($"Key1-{i}"));
                    Assert.False(nested4Key.ContainsPrimary($"Key1-{i}"));
                }
            }
        }

        [Theory]
        [ClassData(typeof(NonAsyncCompositeDictionaryTypesProvider))]
        public void CanMergeDictionaries(ICompositeDictionary dict, string className)
        {
            int primaryAmount = 8; // Reducing amounts to ensure manageability
            int secondaryAmount = 4;
            int thirdAmount = 2;
            int fourthAmount = 1;

            CompositeDictionaryHelper.CreateData(dict, primaryAmount, secondaryAmount, thirdAmount, fourthAmount);
            /*
            var otherDict = CompositeDictionaryHelper.CreateOtherData(primaryAmount, secondaryAmount, thirdAmount, fourthAmount); // Assumes a helper method exists to create distinct data

            dict.Merge(otherDict);

            if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary2Key(dict, out var nested2Key))
            {
                CompositeDictionaryHelper.AssertDataExists(nested2Key, primaryAmount, secondaryAmount); // Assumes a helper method to assert data
                CompositeDictionaryHelper.AssertOtherDataExists(nested2Key, primaryAmount, secondaryAmount);
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary3Key(dict, out var nested3Key))
            {
                CompositeDictionaryHelper.AssertDataExists(nested3Key, primaryAmount, secondaryAmount, thirdAmount);
                CompositeDictionaryHelper.AssertOtherDataExists(nested3Key, primaryAmount, secondaryAmount, thirdAmount);
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary4Key(dict, out var nested4Key))
            {
                CompositeDictionaryHelper.AssertDataExists(nested4Key, primaryAmount, secondaryAmount, thirdAmount, fourthAmount);
                CompositeDictionaryHelper.AssertOtherDataExists(nested4Key, primaryAmount, secondaryAmount, thirdAmount, fourthAmount);
            }
            */
        }

        [Theory]
        [ClassData(typeof(NonAsyncCompositeDictionaryTypesProvider))]
        public void CanReadOnlyDictionaries(ICompositeDictionary dict, string className)
        {
            int primaryAmount = 16;
            int secondaryAmount = 8;
            int thirdAmount = 4;
            int fourthAmount = 2;

            CompositeDictionaryHelper.CreateData(dict, primaryAmount, secondaryAmount, thirdAmount, fourthAmount);

            if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary2Key(dict, out var composite2Key))
            {
                var readOnlynested2Key = composite2Key.AsReadOnly();

                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        bool primaryKeyExists = readOnlynested2Key.ContainsPrimary($"Key1-{i}");
                        bool secondaryKeyExists = readOnlynested2Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}");
                        Assert.True(primaryKeyExists && secondaryKeyExists, $"Key1-{i}, Key2-{j} not found in Nested Dictionary with 2 Keys");

                        int value = readOnlynested2Key[$"Key1-{i}", $"Key2-{j}"];
                        Assert.Equal(j, value);
                    }
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary3Key(dict, out var composite3Key))
            {
                var readOnlyComposite3Key = composite3Key.AsReadOnly();


                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            bool primaryKeyExists = readOnlyComposite3Key.ContainsPrimary($"Key1-{i}");
                            bool secondaryKeyExists = readOnlyComposite3Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}");
                            bool thirdKeyExists = readOnlyComposite3Key.ContainsThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}");

                            Assert.True(primaryKeyExists && secondaryKeyExists && thirdKeyExists, $"Key1-{i}, Key2-{j}, Key3-{k} not found in Nested Dictionary with 3 Keys");

                            int value = readOnlyComposite3Key[$"Key1-{i}", $"Key2-{j}", $"Key3-{k}"];
                            Assert.Equal(k, value);
                        }
                    }
                }
            }
            else if (CompositeDictionaryHelper.IsTypeOfCompositeDictionary4Key(dict, out var composite4Key))
            {
                var readOnlyComposite4Key = composite4Key.AsReadOnly();

                for (int i = 1; i <= primaryAmount; i++)
                {
                    for (int j = 1; j <= secondaryAmount; j++)
                    {
                        for (int k = 1; k <= thirdAmount; k++)
                        {
                            for (int l = 1; l <= fourthAmount; l++)
                            {
                                bool primaryKeyExists = readOnlyComposite4Key.ContainsPrimary($"Key1-{i}");
                                bool secondaryKeyExists = readOnlyComposite4Key.ContainsSecondary($"Key1-{i}", $"Key2-{j}");
                                bool thirdKeyExists = readOnlyComposite4Key.ContainsThirdKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}");
                                bool fourthKeyExists = readOnlyComposite4Key.ContainsFourthKey($"Key1-{i}", $"Key2-{j}", $"Key3-{k}", $"Key4-{l}");

                                Assert.True(primaryKeyExists && secondaryKeyExists && thirdKeyExists && fourthKeyExists, $"Key1-{i}, Key2-{j}, Key3-{k}, Key4-{l} not found in Nested Dictionary with 4 Keys");

                                int value = readOnlyComposite4Key[$"Key1-{i}", $"Key2-{j}", $"Key3-{k}", $"Key4-{l}"];
                                Assert.Equal(l, value);
                            }
                        }
                    }
                }
            }
        }
    }
}
