using System.Collections.Generic;

namespace overflow
{
    public class CalculationResult
    {
        public decimal Volume { get; }
        public IEnumerable<Glass> Glasses { get; }

        public CalculationResult(decimal volume, IEnumerable<Glass> glasses)
        {
            Volume = volume;
            Glasses = glasses;
        }
    }
}