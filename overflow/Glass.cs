using System;

namespace overflow
{
    internal class Glass
    {
        public static decimal Capacity { get; } = 0.25m;

        public decimal Fill { get; }
        public decimal Spill { get; }

        public Glass(decimal poured)
        {
            if (poured < 0) throw new ArgumentOutOfRangeException(nameof(poured), poured, "Cannot pour negative volumes");

            Fill = Math.Min(Capacity, poured);
            Spill = poured - Fill;
        }
    }
}