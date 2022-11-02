using System.Collections.Generic;

namespace PatternsLab2
{
    class CurveChain : ICurve
    {
        private List<ICurve> ChainedCurves;
        private int CurvesCount;
        List<FragmentDecorator> Fragments;

        public CurveChain(List<ICurve> curves)
        {
            this.ChainedCurves = curves;
            this.CurvesCount = curves.Count;

            Fragments = new List<FragmentDecorator>();
            double chainDivider = 1 / (double)CurvesCount;
            for (int i = 1; i < CurvesCount + 1; i++)
            {
                Fragments.Add(new FragmentDecorator(ChainedCurves[i - 1], chainDivider * (i - 1), chainDivider * i));
            }

            for (int i = 1; i < CurvesCount; i++)
            {
                Fragments[i - 1].GetPoint(1, out IPoint endPoint);
                FragmentDecorator buf = new FragmentDecorator(new MoveToDecorator(Fragments[i], endPoint), Fragments[i].tmin, Fragments[i].tmax);
                Fragments[i] = buf;
            }

        }

        public ICurve GetComponent()
        {
            return this;
        }
        public void GetPoint(double t, out IPoint p)
        {
            double chainDivider = 1 / (double)CurvesCount;
            int chainedCurveNumber = 0;

            for (int i = 1; i < CurvesCount + 1; i++)
            {
                if (t > chainDivider * (i - 1) && t <= chainDivider * i)
                {
                    chainedCurveNumber = i - 1;
                }
            }

            double curt = (t - Fragments[chainedCurveNumber].tmin) / (Fragments[chainedCurveNumber].tmax - Fragments[chainedCurveNumber].tmin);
            Fragments[chainedCurveNumber].GetPoint(curt, out p);
        }
    }
}
