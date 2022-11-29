namespace PatternsLab2
{
    public interface IIterable
    {
        void Iterate(Iterator i);
    }

    public delegate void Iterator(IIterable obj);
}
