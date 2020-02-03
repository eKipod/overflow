using System;
using System.Collections.Generic;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("overflow.test")]

namespace overflow
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public CalculationResult GetVolume(uint row, uint index, decimal poured)
        {
            if (poured < 0) throw new ArgumentOutOfRangeException(nameof(poured), poured, "Value cannot be negative");
            if (index > row) throw new ArgumentOutOfRangeException(nameof(index), index, $"Row {row} only has {row + 1} glasses");

            var rows = row + 1;

            var lastRow = Array.Empty<Glass>();
            for(var r = 0; r < rows; r++)
            {
                var indexesInRow = r + 1;
                var currentRow = new Glass[indexesInRow];

                for(var i = 0; i < indexesInRow; i++)
                {
                    if (r == 0 && i == 0)
                    {
                        currentRow[i] = new Glass(poured);
                    }
                    else
                    {
                        var upperLeftSpill = i == 0 ? 0 : lastRow[i - 1].Spill;
                        var upperRightSpill = i == indexesInRow - 1 ? 0 : lastRow[i].Spill;

                        currentRow[i] = new Glass(0.5m * upperLeftSpill + 0.5m * upperRightSpill);
                    }
                    if (r == row && i == index) return new CalculationResult(currentRow[i].Fill);
                }
                lastRow = currentRow;
            }
            
            throw new Exception("This should never happen");
        }
    }
}