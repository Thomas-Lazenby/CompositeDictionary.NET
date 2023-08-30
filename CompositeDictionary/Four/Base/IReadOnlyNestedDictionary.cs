

namespace CompositeDictionary
{
    public interface IReadOnlyNestedDictionary<TPrimaryKey, TSecondaryKey, TThirdKey, TFourthKey, TValue>
        where TPrimaryKey : notnull
        where TSecondaryKey : notnull
        where TThirdKey : notnull
        where TFourthKey : notnull
    {
        IEnumerable<TPrimaryKey> GetPrimaryKeys();
        IEnumerable<TSecondaryKey> GetSecondaryKeys(TPrimaryKey primaryKey);
        IEnumerable<TThirdKey> GetThirdKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);
        IEnumerable<TFourthKey> GetFourthKeys(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);
        TValue this[TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey] { get; }
        bool ContainsPrimary(TPrimaryKey primaryKey);
        bool ContainsSecondary(TPrimaryKey primaryKey, TSecondaryKey secondaryKey);
        bool ContainsThirdKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey);
        bool ContainsFourthKey(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey);
        bool TryGetValue(TPrimaryKey primaryKey, TSecondaryKey secondaryKey, TThirdKey thirdKey, TFourthKey fourthKey, out TValue value);
        int Count { get; }
        bool IsEmpty();
    }
}
