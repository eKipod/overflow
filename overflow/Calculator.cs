using System;

namespace overflow
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public CalculationResult GetVolume(uint row, uint index, decimal inVolume)
        {
            if (inVolume < 0) throw new ArgumentOutOfRangeException(nameof(inVolume), inVolume, "Value cannot be negative");
            if (index > row) throw new ArgumentOutOfRangeException(nameof(index), index, $"Row {row} only has {row + 1} glasses");
            return new CalculationResult(Math.Min(1, inVolume));
        }
    }
}