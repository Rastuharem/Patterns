using System.Collections.Generic;
using System.Drawing;

namespace PatternsLab2
{
    class AddCommand : ACommand
    {
        private ICurve CurCurve;

        public AddCommand(ICurve CurCurve, List<ICurve> Curves, Graphics Graphics1, Graphics Graphics2, DrawBySVG SVG) 
            : base(Curves, Graphics1, Graphics2, SVG)
        {
            this.CurCurve = CurCurve;
        }

        protected override void doExecute()
        {
            AllCurves.Add(CurCurve);
            new VisualCurve(CurCurve, new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
            new VisualCurve(CurCurve, new DrawByGraphicsStyle2(g2, 3)).Draw(50);
            new VisualCurve(CurCurve, SVG).Draw(50);
        }
        public override ACommand Clone()
        {
            return new AddCommand(CurCurve, AllCurves, g1, g2, SVG);
        }
    }
}