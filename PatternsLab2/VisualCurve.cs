namespace PatternsLab2
{
    class VisualCurve : ICurve, IDrawable
    {
        private ICurve Curve;
        private IDrawByContext Context;

        public VisualCurve(ICurve curve, IDrawByContext context)
        {
            this.Curve = curve;
            this.Context = context;
        }

        public void GetPoint(double t, out IPoint p)
        {
            Curve.GetPoint(t, out p);
        }

        public void Draw(int n)
        {
            StrategyContext StratCont = new StrategyContext(new ConcreteStrategicGetL(this.Curve));

            GetPoint(0, out IPoint startPoint);
            GetPoint(1, out IPoint endPoint);
            Context.DrawStartPoint(startPoint);
            Context.DrawEndPoint(endPoint);

            double L = 0;
            double bufT = 0;
            for (int i = 0; i < n; i++)
            {
                double t = (double)i / (double)n;

                GetPoint(bufT, out IPoint Point1);
                GetPoint(t, out IPoint Point2);
                Context.DrawLine(Point1, Point2);

                L += StratCont.ExecuteStrategy(t, L, n);
                bufT = t;
            }
            GetPoint(bufT, out IPoint Point);
            Context.DrawLine(Point, endPoint);

            StratCont.SetStrategy(new ConcreteStrategicGetT(this.Curve));
            double CentralT = StratCont.ExecuteStrategy(0, L / 2, n);
            GetPoint(CentralT, out IPoint CentralPoint);
            Context.DrawCentralPoint(CentralPoint);
        }

        public ICurve GetComponent()
        {
            return this;
        }
        public void Iterate(Iterator i)
        {
            this.Curve.Iterate(i);
        }
    }
}
