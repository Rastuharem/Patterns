namespace PatternsLab2
{
    public interface ICurve : IIterable
    {
        void GetPoint(double t, out IPoint p);
        ICurve GetComponent();
    }
}
