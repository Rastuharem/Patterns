namespace PatternsLab2
{
    class DrawBySVG : IDrawByContext
    {
        private string result;

        public DrawBySVG()
        {
            result = "<svg viewBox = " + '"' + "0 0 100 100" + '"' + " xmlns = " + '"' + "http://www.w3.org/2000/svg" + '"' + '>';
        }
        public void DrawLine(IPoint point1, IPoint point2)
        {
            result += "<line x1 = " + '"' + point1.GetCoordX() + '"' + " y1 = " + '"' + point1.GetCoordY() + '"' + " x2 = " + '"' + point2.GetCoordX() + '"'
                + " y2 = " + '"' + point2.GetCoordY() + '"' +" stroke = " + '"' + "black" + '"' + "/>";
        }

        public void DrawStartPoint(IPoint p1) { }
        public void DrawEndPoint(IPoint p1) { }
        public void DrawCentralPoint(IPoint p1) { }

        public string GetResult()
        {
            result += "</svg >";
            return result; 
        }
    }
}
