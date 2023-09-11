

namespace CompositeDictionary
{
    public interface IReadOnlyCompositeDictionary
    {
        int Count { get; }
        
        bool IsEmpty();
    }
}
