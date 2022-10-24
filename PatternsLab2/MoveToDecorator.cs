using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLab2
{
    class MoveToDecorator : ICurve
    {
        private IPoint OffsetPoint;
        ICurve Curve;

        public MoveToDecorator(ICurve Curve, IPoint p)
        {
            this.Curve = Curve;
            this.OffsetPoint = p;
        }

        public void GetPoint(double t, out IPoint p)
        {
            Curve.GetPoint(0, out IPoint StartPoint);
            double OffsetByX = OffsetPoint.GetCoordX() - StartPoint.GetCoordX();
            double OffsetByY = OffsetPoint.GetCoordY() - StartPoint.GetCoordY();

            Curve.GetPoint(t, out p);
            p.SetCoordX(p.GetCoordX()+OffsetByX);
            p.SetCoordY(p.GetCoordY()+OffsetByY);
        }

        public ICurve GetComponent()
        {
            return Curve.GetComponent();
        }
    }
}
