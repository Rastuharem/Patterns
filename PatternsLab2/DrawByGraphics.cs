using System.Drawing;

namespace PatternsLab2
{
    class DrawByGraphics : IDrawByContext
    {
        protected Brush brush;
        protected double thickness;
        protected Graphics g;

        public DrawByGraphics(Graphics g, Color color, double thickness)
        {
            this.g = g;
            this.brush = new SolidBrush(color);
            this.thickness = thickness;
        }

        public virtual void DrawStartPoint(IPoint p)
        {
            g.FillEllipse(brush, new RectangleF((float)(p.GetCoordX() - thickness / 2F), (float)(p.GetCoordY() - thickness / 2F), (float)thickness, (float)thickness));
        }
        public virtual void DrawEndPoint(IPoint p)
        {
            this.DrawStartPoint(p);
        }
        public virtual void DrawCentralPoint(IPoint p)
        {
            g.FillEllipse(Brushes.Red, new RectangleF((float)(p.GetCoordX() - thickness - 5), (float)(p.GetCoordY() - thickness - 5), (float)thickness + 10, (float)thickness + 10));
        }
        public virtual void DrawLine(IPoint startPoint, IPoint endPoint)
        {
            Pen pen = new Pen(((SolidBrush)brush).Color, (float)thickness);
            g.DrawLine(pen, new PointF((float)startPoint.GetCoordX(), (float)startPoint.GetCoordY()), new PointF((float)endPoint.GetCoordX(), (float)endPoint.GetCoordY()));
        }
    }
}
