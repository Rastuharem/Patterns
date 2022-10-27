namespace PatternsLab2
{
    class FragmentDecorator : ICurve
    {
        private double tmin, tmax;
        private ICurve Curve;

        public FragmentDecorator(ICurve Curve, double tmin, double tmax)
        {
            this.Curve = Curve;
            this.tmin = tmin;
            this.tmax = tmax;
        }

        public void GetPoint(double t, out IPoint p)
        {
            Curve.GetPoint((tmin + t*(tmax-tmin)), out p);
        }

        public ICurve GetComponent()
        {
            return Curve.GetComponent();
        }

        public void SetTMin(double t)
        {
            this.tmin = t;
        }
        public void SetTMax(double t)
        {
            this.tmax = t;
        }
    }
}
