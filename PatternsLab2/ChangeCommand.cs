using System.Collections.Generic;
using System.Drawing;

namespace PatternsLab2
{
    class ChangeCommand : ACommand
    {
        private ICurve CurCurve;
        //private ICurve OldCurve;

        public ChangeCommand(ICurve CurCurve, List<ICurve> Curves, Graphics Graphics1, Graphics Graphics2, DrawBySVG SVG)
            : base(Curves, Graphics1, Graphics2, SVG)
        {
            this.CurCurve = CurCurve;
            //OldCurve = Curves[Curves.Count - 1];
        }
        protected override void doExecute()
        {
            AllCurves[AllCurves.Count - 1] = CurCurve;
            g1.Clear(Color.White);
            g2.Clear(Color.White);

            for (int i = 0; i < AllCurves.Count; i++)
            {
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle1(g1, 3)).Draw(1000);
                new VisualCurve(AllCurves[i], new DrawByGraphicsStyle2(g2, 3)).Draw(50);
            }
        }

        public override ACommand Clone()
        {
            return new ChangeCommand(CurCurve, AllCurves, g1, g2, SVG);
        }
    }
}