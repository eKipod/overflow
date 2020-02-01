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
        [InlineData(0, 0)]
        [InlineData(0.9, 0.9)]
        [InlineData(1, 1)]
        [InlineData(1.1, 1)]
        public void TopGlass(decimal inVolume, decimal expectedVolume)
        {
            var calc = new Calculator();
            var result = calc.GetVolume(row: 0, index: 0, inVolume: inVolume);
            Assert.NotNull(result);
            Assert.Equal(expectedVolume, result.Volume);
        }


        [Fact]
        public void NegativeVolumeIsInvalid()
        {
            var calc = new Calculator();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.GetVolume(0, 0, -1));
        }

    }
}
