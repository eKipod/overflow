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
    }
}
