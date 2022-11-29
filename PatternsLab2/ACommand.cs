using System.Collections.Generic;
using System.Drawing;

namespace PatternsLab2
{
    abstract class ACommand : ICommand
    {
        protected Graphics g1, g2;
        protected List<ICurve> AllCurves;
        protected DrawBySVG SVG;

        public ACommand(List<ICurve> Curves, Graphics Graphics1, Graphics Graphics2, DrawBySVG SVG)
        {
            this.SVG = SVG;
            g1 = Graphics1;
            g2 = Graphics2;
            AllCurves = Curves;
        }

        public void Ecexute()
        {
            CommandManager CM = CommandManager.GetInstance();
            CM.Registry(Clone());
            doExecute();
        }

        protected abstract void doExecute();
        public abstract ACommand Clone();
    }
}