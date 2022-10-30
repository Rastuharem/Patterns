namespace PatternsLab2
{
    class FragmentDecorator : ICurve
    {
        public double tmin { get; set; }
        public double tmax { get; set; }
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
    }
}
