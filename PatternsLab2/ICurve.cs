namespace PatternsLab2
{
    interface ICurve
    {
        void GetPoint(double t, out IPoint p);
        ICurve GetComponent();
    }
}
