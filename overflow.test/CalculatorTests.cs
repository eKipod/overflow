using Xunit;
using overflow;

namespace overflow.test
{
    public class CalculatorTests
    {
        [Fact]
        public void CreateCalculator()
        {
            var calc = new Calculator();
            Assert.NotNull(calc);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void CalculateTopGlass(uint inVolume, uint expectedVolume)
        {
            var calc = new Calculator();
            var result = calc.GetVolume(row: 0, index: 0, inVolume: inVolume);
            Assert.NotNull(result);
            Assert.Equal(expectedVolume, result.Volume);
        }

    }
}
