using System;
using System.Collections.Generic;
using System.Linq;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("overflow.test")]

namespace overflow
{
    public static class Calculator
    {
        public static CalculationResult GetVolume(uint row, uint index, decimal poured)
        {
            if (poured < 0) throw new ArgumentOutOfRangeException(nameof(poured), poured, "Value cannot be negative");
            if (index > row) throw new ArgumentOutOfRangeException(nameof(index), index, $"Row {row} only has {row + 1} glasses");

            var glasses = FillGlasses(poured)
                .TakeWhile(g => g.Row < row || (g.Row == row && g.Index <= index))
                .ToList();

            return new CalculationResult(glasses.Last().Fill, glasses);
        }

        private static IEnumerable<Glass> FillGlasses(decimal poured)
        {
            var lastRow = Array.Empty<Glass>();
            var r = 0u;
            while(true)
            {
                var indexesInRow = r + 1;
                var currentRow = new Glass[indexesInRow];

                for (var i = 0u; i < indexesInRow; i++)
                {
                    if (r == 0 && i == 0)
                    {
                        currentRow[i] = new Glass(r, i, poured);
                    }
                    else
                    {
                        var upperLeftSpill = i == 0 ? 0 : lastRow[i - 1].Spill;
                        var upperRightSpill = i == indexesInRow - 1 ? 0 : lastRow[i].Spill;

                        currentRow[i] = new Glass(r, i, 0.5m * upperLeftSpill + 0.5m * upperRightSpill);
                    }
                    yield return currentRow[i];
                }
                r++;
                lastRow = currentRow;
            }
        }
    }
}