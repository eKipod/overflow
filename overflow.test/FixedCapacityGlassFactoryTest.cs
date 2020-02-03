using System;
using Xunit;

namespace overflow.test
{
    public class FixedCapacityGlassFactoryTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0.25, 0.25, 0)]
        [InlineData(0.251, 0.25, 0.001)]
        [InlineData(1, 0.25, 0.75)]
        public void CreateGlassWithCapacity(decimal poured, decimal expectedFill, decimal expectedSpill)
        {
            var target = new FixedCapacityGlassFactory(0.25m);

            var glass = target.CreateGlass(0, 0, poured);

            Assert.Equal(expectedFill, glass.Fill);
            Assert.Equal(expectedSpill, glass.Spill);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void CreateGlassWithZeroCapacity(decimal poured)
        {
            var target = new FixedCapacityGlassFactory(0);

            var glass = target.CreateGlass(0, 0, poured);

            Assert.Equal(0, glass.Fill);
            Assert.Equal(poured, glass.Spill);
        }

        [Fact]
        public void NegativeCapacityIsIvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FixedCapacityGlassFactory(-0.1m));
        }

        [Fact]
        public void IndexNotInRowIsInvalid()
        {
            var target = new FixedCapacityGlassFactory(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => target.CreateGlass(2, 3, 10));
        }

        [Fact]
        public void CreateSameGlassTwiceIsInvalid()
        {
            var target = new FixedCapacityGlassFactory(1);
            target.CreateGlass(2, 1, 0);
            Assert.Throws<InvalidOperationException>(() => target.CreateGlass(2, 1, 10));
        }

        [Fact]
        public void PourNegativeAmountIsInvalid()
        {
            var target = new FixedCapacityGlassFactory(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => target.CreateGlass(2, 1, -0.5m));
        }

    }
}
