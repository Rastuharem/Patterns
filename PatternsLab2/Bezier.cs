using System;

namespace PatternsLab2
{
    class Bezier : ACurve
    {
        private IPoint controlPoint1;
        private IPoint controlPoint2;

        public Bezier(IPoint startPoint, IPoint endPoint, IPoint controlPoint1, IPoint controlPoint2) : base(startPoint, endPoint)
        {
            this.controlPoint1 = controlPoint1;
            this.controlPoint2 = controlPoint2;
        }

        public override void GetPoint(double t, out IPoint p)
        {
            p = new Point(BezierFunc(t, base.GetA().GetCoordX(), base.GetB().GetCoordX(), controlPoint1.GetCoordX(), controlPoint2.GetCoordX()),
                          BezierFunc(t, base.GetA().GetCoordY(), base.GetB().GetCoordY(), controlPoint1.GetCoordY(), controlPoint2.GetCoordY()));
        }

        private double BezierFunc(double t, double x1, double x2, double x3, double x4)
        {
            return (Math.Pow((1 - t), 3) * x1 + 3 * t * Math.Pow((1 - t), 2) * x3 + 3 * Math.Pow(t, 2) * (1 - t) * x4 + Math.Pow(t, 3) * x2);
        }
    }
}
