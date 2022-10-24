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

        public IPoint GetStartPoint() { return startPoint; }
        public IPoint GetEndPoint() { return endPoint; }

        public ICurve GetComponent()
        {
            return this;
        }
    }
}
