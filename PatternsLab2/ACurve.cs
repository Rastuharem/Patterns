namespace PatternsLab2
{
    abstract class ACurve : ICurve
    {
        private IPoint startPoint;
        private IPoint endPoint;

        public ACurve(IPoint startPoint, IPoint endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        abstract public void GetPoint(double t, out IPoint p);

        public IPoint GetA() { return startPoint; }
        public IPoint GetB() { return endPoint; }
    }
}
