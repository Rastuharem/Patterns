namespace PatternsLab2
{
    public interface IDrawByContext
    {
        void DrawLine(IPoint p1, IPoint p2);
        void DrawStartPoint(IPoint p);
        void DrawEndPoint(IPoint p);
        void DrawCentralPoint(IPoint p);
    }
}
