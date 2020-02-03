using System.Collections.Generic;

namespace overflow
{
    public class CalculationResult
    {
        public decimal Volume { get; }
        public IEnumerable<IGlass> Glasses { get; }

        public CalculationResult(decimal volume, IEnumerable<IGlass> glasses)
        {
            Volume = volume;
            Glasses = glasses;
        }
    }
}