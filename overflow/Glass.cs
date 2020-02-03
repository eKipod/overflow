using System;

namespace overflow
{
    public class Glass
    {
        public static decimal Capacity { get; } = 0.25m;

        public uint Row { get; }
        public uint Index { get; }
        public decimal Fill { get; }
        public decimal Spill { get; }

        public Glass(uint row, uint index, decimal poured)
        {
            if (poured < 0) throw new ArgumentOutOfRangeException(nameof(poured), poured, "Cannot pour negative volumes");

            Row = row;
            Index = index;
            Fill = Math.Min(Capacity, poured);
            Spill = poured - Fill;
        }
    }
}