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

            return new CalculationResult(Math.Min(1, inVolume));
        }
    }
}