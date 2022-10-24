namespace PatternsLab2
{
    class Line : ACurve
    {
        public Line(IPoint startPoint, IPoint endPoint) : base(startPoint, endPoint) { }

        public override void GetPoint(double t, out IPoint p)
        {
            p = new Point(LinearFunc(t, base.GetStartPoint().GetCoordX(), base.GetEndPoint().GetCoordX()), LinearFunc(t, base.GetStartPoint().GetCoordY(), base.GetEndPoint().GetCoordY()));
        }

        private double LinearFunc (double t, double x1, double x2)
        {
            return ((1 - t) * x1 + t * x2);
        }
    }
}
