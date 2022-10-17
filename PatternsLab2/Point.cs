namespace PatternsLab2
{
    class Point : IPoint
    {
        private double X;
        private double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double GetCoordX() { return X; }
        public double GetCoordY() { return Y; }
        public void SetCoordX(double x) { X = x; }
        public void SetCoordY(double y) { Y = y; }
    }
}
