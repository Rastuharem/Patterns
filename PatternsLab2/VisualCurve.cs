namespace PatternsLab2
{
    class VisualCurve : ICurve, IDrawable
    {
        private ICurve curve;
        private IDrawByContext context;

        public VisualCurve(ICurve curve, IDrawByContext context)
        {
            this.curve = curve;
            this.context = context;
        }

        public void GetPoint(double t, out IPoint p)
        {
            curve.GetPoint(t, out p);
        }

        public void Draw(int n)
        {
            GetPoint(0, out IPoint startPoint);
            GetPoint(1, out IPoint endPoint);
            context.DrawStartPoint(startPoint);
            context.DrawEndPoint(endPoint);

            double bufT = 0;
            for (int i = 0; i < n; i++)
            {
                double t = (double)i / (double)n;

                GetPoint(bufT, out IPoint Point1);
                GetPoint(t, out IPoint Point2);

                context.DrawLine(Point1, Point2);

                bufT = t;
            }
            GetPoint(bufT, out IPoint Point);
            context.DrawLine(Point, endPoint);
        }
    }
}
