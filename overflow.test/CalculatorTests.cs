using Xunit;
using overflow;
using System;

namespace overflow.test
{
    public class CalculatorTests
    {
        [Fact]
        public void Create()
        {
            var calc = new Calculator();
            Assert.NotNull(calc);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 0, 0.9, 0.9)]
        [InlineData(0, 0, 1, 1)]
        [InlineData(0, 0, 1.1, 1)]

        public void CalculateVolume(uint row, uint index, decimal inVolume, decimal expectedVolume)
        {
            var calc = new Calculator();
            var result = calc.GetVolume(row: row, index: index, inVolume: inVolume);
            Assert.NotNull(result);
            Assert.Equal(expectedVolume, result.Volume);
        }


        [Fact]
        public void NegativeVolumeIsError()
        {
            var calc = new Calculator();
            Assert.Throws<ArgumentOutOfRangeException>("inVolume", () => calc.GetVolume(0, 0, -1));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(16, 17)]
        public void IndexOutOfRangeIsError(uint row, uint index)
        {
            var calc = new Calculator();
            Assert.Throws<ArgumentOutOfRangeException>("index", () => calc.GetVolume(row, index, 0));
        }
    }
}
