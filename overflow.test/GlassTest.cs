using Xunit;

namespace overflow.test
{
    public class GlassTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0.25, 0.25, 0)]
        [InlineData(0.251, 0.25, 0.001)]
        [InlineData(1, 0.25, 0.75)]
        public void CreateGlass(decimal poured, decimal expectedFill, decimal expectedSpill)
        {
            var glass = new Glass(0, 0, poured);

            Assert.Equal(expectedFill, glass.Fill);
            Assert.Equal(expectedSpill, glass.Spill);
        }
    }
}
