using Xunit;
using overflow;
using System;
using System.Linq;

namespace overflow.test
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 0, 0.9, 0.9)]
        [InlineData(0, 0, 1, 1)]
        [InlineData(0, 0, 1.1, 1)]

        [InlineData(1, 0, 1, 0)]
        [InlineData(1, 1, 1, 0)]
        [InlineData(1, 0, 2, 0.5)]
        [InlineData(1, 1, 2, 0.5)]

        [InlineData(3, 0, 7, 0)]
        [InlineData(3, 1, 7, 0.5)]
        [InlineData(3, 2, 7, 0.5)]
        [InlineData(3, 3, 7, 0)]

        [InlineData(3, 0, 10, 0.375)]
        [InlineData(3, 1, 10, 1)]
        [InlineData(3, 2, 10, 1)]
        [InlineData(3, 3, 10, 0.375)]
        public void CalculateVolume(uint row, uint index, decimal inVolume, decimal expectedVolume)
        {
            // Calculating for glass capcity of 1 is easier than 0.25, so adjust the numbers:
            var inVolumeAdjusted = inVolume * Glass.Capacity;
            var expectedVolumeAdjusted = expectedVolume * Glass.Capacity;

            var result = Calculator.GetVolume(row: row, index: index, poured: inVolumeAdjusted);
            Assert.NotNull(result);
            Assert.Equal(expectedVolumeAdjusted, result.Volume);
        }

        [Fact]
        public void CalculateGlasses()
        {
            var row = 3u;
            var index = 3u;
            var poured = 10m * Glass.Capacity;
            var expectedVolume = 0.375m * Glass.Capacity;

            var expectedGlasses = new (uint row, uint index, decimal fill, decimal spill)[]
            {
                (row: 0, index: 0, fill: 1, spill: 9),
                (row: 1, index: 0, fill: 1, spill: 3.5m), (row: 1, index: 1, fill: 1, spill: 3.5m),
                (row: 2, index: 0, fill: 1, spill: 0.75m), (row: 2, index: 1, fill: 1, spill: 2.5m), (row: 2, index: 2, fill: 1, spill: 0.75m),
                (row: 3, index: 0, fill: 0.375m, spill: 0), (row: 3, index: 1, fill: 1, spill: 0.625m), (row: 3, index: 2, fill: 1, spill: 0.625m), (row: 3, index: 3, fill: 0.375m, spill: 0)
            };

            var result = Calculator.GetVolume(row: row, index: index, poured: poured);
            Assert.NotNull(result);
            Assert.Equal(expectedVolume, result.Volume);
            Assert.Equal(expectedGlasses.Select(g => g.row).ToList(), result.Glasses.OrderBy(g => g.Row).ThenBy(g => g.Index).Select(g => g.Row).ToList());
            Assert.Equal(expectedGlasses.Select(g => g.index).ToList(), result.Glasses.OrderBy(g => g.Row).ThenBy(g => g.Index).Select(g => g.Index).ToList());
            Assert.Equal(expectedGlasses.Select(g => g.fill * Glass.Capacity).ToList(), result.Glasses.OrderBy(g => g.Row).ThenBy(g => g.Index).Select(g => g.Fill).ToList());
            Assert.Equal(expectedGlasses.Select(g => g.spill * Glass.Capacity).ToList(), result.Glasses.OrderBy(g => g.Row).ThenBy(g => g.Index).Select(g => g.Spill).ToList());
        }


        [Fact]
        public void NegativeVolumeIsError()
        {
            Assert.Throws<ArgumentOutOfRangeException>("poured", () => Calculator.GetVolume(0, 0, -1));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(16, 17)]
        public void IndexOutOfRangeIsError(uint row, uint index)
        {
            Assert.Throws<ArgumentOutOfRangeException>("index", () => Calculator.GetVolume(row, index, 0));
        }
    }
}
