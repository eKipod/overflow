using System;
using System.Collections.Generic;
using System.Linq;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("overflow.test")]

namespace overflow
{
    public class Calculator
    {
        private IGlassFactory GlassFactory { get; }
        public Calculator(IGlassFactory glassFactory)
        {
            GlassFactory = glassFactory;
        }

        public CalculationResult GetVolume(uint row, uint index, decimal poured)
        {
            if (poured < 0) throw new ArgumentOutOfRangeException(nameof(poured), poured, "Value cannot be negative");
            if (index > row) throw new ArgumentOutOfRangeException(nameof(index), index, $"Row {row} only has {row + 1} glasses");

            var glasses = FillGlasses(poured)
                .TakeWhile(g => g.Row < row || (g.Row == row && g.Index <= index))
                .ToList();

            return new CalculationResult(glasses.Last().Fill, glasses);
        }

        private IEnumerable<IGlass> FillGlasses(decimal poured)
        {
            var lastRow = Array.Empty<IGlass>();
            var r = 0u;
            while(true)
            {
                var indexesInRow = r + 1;
                var currentRow = new IGlass[indexesInRow];

                for (var i = 0u; i < indexesInRow; i++)
                {
                    if (r == 0 && i == 0)
                    {
                        currentRow[i] = GlassFactory.CreateGlass(r, i, poured);
                    }
                    else
                    {
                        var upperLeftSpill = i == 0 ? 0 : lastRow[i - 1].Spill;
                        var upperRightSpill = i == indexesInRow - 1 ? 0 : lastRow[i].Spill;

                        currentRow[i] = GlassFactory.CreateGlass(r, i, 0.5m * upperLeftSpill + 0.5m * upperRightSpill);
                    }
                    yield return currentRow[i];
                }
                r++;
                lastRow = currentRow;
            }
        }
    }
}