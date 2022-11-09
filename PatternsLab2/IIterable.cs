namespace PatternsLab2
{
    interface IIterable
    {
        void Iterate(Iterator i);
    }

    delegate void Iterator(IIterable obj);
}
