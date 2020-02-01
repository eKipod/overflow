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

        [Fact]
        public void CalculateTopGlass()
        {
            var calc = new Calculator();
            var result = calc.GetVolume(row: 0, index: 0, inVolume: 0);
            Assert.NotNull(result);
            Assert.Equal(0, result.Volume);
        }
    }
}
