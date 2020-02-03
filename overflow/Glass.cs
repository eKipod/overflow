using System;

namespace overflow
{
    internal class Glass
    {
        public decimal Capacity { get; } = 1;

        public decimal Fill { get; }
        public decimal Spill { get; }

        public Glass(decimal pour)
        {
            if (pour < 0) throw new ArgumentOutOfRangeException(nameof(pour), pour, "Cannot pour negative volumes");

            Fill = Math.Min(Capacity, pour);
            Spill = pour - Fill;
        }
    }
}