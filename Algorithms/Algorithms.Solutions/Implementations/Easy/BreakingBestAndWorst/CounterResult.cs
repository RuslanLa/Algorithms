namespace Algorithms.Solutions.Implementations.Easy.BreakingBestAndWorst
{
    /// <summary>
    /// Result of the best and worst breakings counter
    /// </summary>
    public class CounterResult
    {
        /// <summary>
        /// Best count
        /// </summary>
        public readonly int Best;

        /// <summary>
        /// Worst count
        /// </summary>
        public readonly int Worst;

        public CounterResult(int worst, int best)
        {
            Best = best;
            Worst = worst;
        }
    }
}
