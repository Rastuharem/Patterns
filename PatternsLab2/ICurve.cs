namespace PatternsLab2
{
    interface ICurve : IIterable
    {
        void GetPoint(double t, out IPoint p);
        ICurve GetComponent();
    }
}
