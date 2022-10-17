using System;
using System.Drawing;

namespace PatternsLab2
{
    class DrawByGraphicsStyle1 : DrawByGraphics
    {
        public DrawByGraphicsStyle1(Graphics g, double thickness) : base(g, Color.Green, thickness) { }

        public override void DrawStartPoint(IPoint p)
        {
            g.FillEllipse(brush, new RectangleF((float)(p.GetCoordX() - thickness-5), (float)(p.GetCoordY() - thickness-5), (float)thickness+10, (float)thickness+10));
        }
        public override void DrawEndPoint(IPoint p)
        {
            this.DrawArrow(p.GetCoordX(), p.GetCoordY(), p.GetCoordX() + p.GetCoordX() / 50, p.GetCoordY() + p.GetCoordY() / 50);
        }

        private void DrawArrow(double x1, double y1, double x2, double y2, int arrLength = 30)
        {
            var m = x2 - x1 == 0 ? 0 : (y2 - y1) / (x2 - x1);
            var degree = Math.Atan(m);

            var toLeft = x2 > x1 ? 0 : Math.PI;

            var degree1 = degree + 5 * Math.PI / 6 + toLeft;
            var degree2 = degree + 7 * Math.PI / 6 + toLeft;

            var px1 = x2 + Math.Cos(degree1) * arrLength;
            var py1 = y2 + Math.Sin(degree1) * arrLength;

            var px2 = x2 + Math.Cos(degree2) * arrLength;
            var py2 = y2 + Math.Sin(degree2) * arrLength;

            var pen = new Pen(((SolidBrush)brush).Color, (float)thickness);

            g.DrawLine(pen, (float)x2, (float)y2, (float)px1, (float)py1);
            g.DrawLine(pen, (float)x2, (float)y2, (float)px2, (float)py2);
        }
    }
}
