using System;

namespace PatternsLab2
{
    class ConcreteStrategicGetL : IStrategy
    {
        private ICurve curve;

        public ConcreteStrategicGetL(ICurve curve)
        {
            this.curve = curve;
        }

        public double Execute(double t, double L, int n)
        {
            double bufT = t - (double)1/(double)n;

            curve.GetPoint(bufT, out IPoint Point1);
            curve.GetPoint(t, out IPoint Point2);

            return this.GetLengthByPoints(Point1, Point2);
        }

        private double GetLengthByPoints(IPoint point1, IPoint point2)
        {
            return Math.Sqrt(Math.Pow(point2.GetCoordY() - point1.GetCoordX(), 2) + Math.Pow(point2.GetCoordX() - point1.GetCoordX(), 2));
        }
    }
}
