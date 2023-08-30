

namespace CompositeDictionary
{
    public interface ICompositeDictionary
    {
        void Clear();

        int Count { get; }
        
        bool IsEmpty();

    }
}
