using System.Drawing;

namespace PatternsLab2
{
    class DrawByGraphicsStyle2 : DrawByGraphics
    {
        public DrawByGraphicsStyle2(Graphics g, double thickness) : base(g, Color.Black, thickness) { }

        public override void DrawStartPoint(IPoint p)
        {
            g.FillRectangle(brush, new RectangleF((float)(p.GetCoordX() - thickness - 5), (float)(p.GetCoordY() - thickness - 5), (float)thickness + 10, (float)thickness + 10));
        }
        public override void DrawEndPoint(IPoint p)
        {
            this.DrawStartPoint(p);
        }
        public override void DrawLine(IPoint startPoint, IPoint endPoint)
        {
            Pen pen = new Pen(((SolidBrush)brush).Color, (float)thickness);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            g.DrawLine(pen, new PointF((float)startPoint.GetCoordX(), (float)startPoint.GetCoordY()), new PointF((float)endPoint.GetCoordX(), (float)endPoint.GetCoordY()));
        }
    }
}
