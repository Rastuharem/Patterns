namespace PatternsLab2
{
    class StrategyContext
    {
        private IStrategy Strategy;

        public StrategyContext(IStrategy Strategy)
        {
            this.Strategy = Strategy;
        }

        public double ExecuteStrategy(double t, double L, int step)
        {
            return Strategy.Execute(t, L, step);
        }

        public void SetStrategy(IStrategy Strategy)
        {
            this.Strategy = Strategy;
        }
    }
}
