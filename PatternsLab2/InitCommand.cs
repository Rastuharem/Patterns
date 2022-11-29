using System.Collections.Generic;
using System.Drawing;

namespace PatternsLab2
{
    class InitCommand : ACommand
    {
        public InitCommand(List<ICurve> Curves, Graphics Graphics1, Graphics Graphics2, DrawBySVG SVG)
            : base(Curves, Graphics1, Graphics2, SVG) { }

        protected override void doExecute()
        {
            AllCurves.Clear();
            g1.Clear(System.Drawing.Color.White);
            g2.Clear(System.Drawing.Color.White);
        }
        public override ACommand Clone()
        {
            return new InitCommand(AllCurves, g1, g2, SVG);
        }
    }
}