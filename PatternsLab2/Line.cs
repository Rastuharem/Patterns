namespace PatternsLab2
{
    class Line : ACurve
    {
        public Line(IPoint startPoint, IPoint endPoint) : base(startPoint, endPoint) { }

        public override void GetPoint(double t, out IPoint p)
        {
            p = new Point(LinearFunc(t, base.GetA().GetCoordX(), base.GetB().GetCoordX()), LinearFunc(t, base.GetA().GetCoordY(), base.GetB().GetCoordY()));
        }

        private double LinearFunc (double t, double x1, double x2)
        {
            return ((1 - t) * x1 + t * x2);
        }
    }
}
