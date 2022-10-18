using System;

namespace PatternsLab2
{
    class ConcreteStrategicGetT : IStrategy
    {
        private ICurve curve;

        public ConcreteStrategicGetT(ICurve curve)
        {
            this.curve = curve;
        }

        public double Execute(double t, double L, int n)
        {
            double currL = 0;
            double bufT = 0;
            for (int i = 0; i < n; i++)
            {
                t = (double)i / (double)n;

                curve.GetPoint(bufT, out IPoint Point1);
                curve.GetPoint(t, out IPoint Point2);

                currL += GetLengthByPoints(Point1, Point2);
                if(currL>=L)
                {
                    return t;
                }

                bufT = t;
            }
                return t;
        }

        private double GetLengthByPoints(IPoint point1, IPoint point2)
        {
            return Math.Sqrt(Math.Pow(point2.GetCoordY() - point1.GetCoordX(), 2) + Math.Pow(point2.GetCoordX() - point1.GetCoordX(), 2));
        }
    }
}
