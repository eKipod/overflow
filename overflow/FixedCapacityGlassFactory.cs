using System;
using System.Collections.Generic;

namespace overflow
{
    public class FixedCapacityGlassFactory : IGlassFactory
    {
        private class Glass : IGlass
        {
            public uint Row { get; }
            public uint Index { get; }
            public decimal Fill { get; }
            public decimal Spill { get; }

            public Glass(uint row, uint index, decimal poured, decimal capacity)
            {
                Row = row;
                Index = index;
                Fill = Math.Min(capacity, poured);
                Spill = poured - Fill;
            }
        }

        private decimal Capacity { get; }

        private ISet<(uint row, uint index)> GlassAllocations { get; } = new HashSet<(uint, uint)>();

        public FixedCapacityGlassFactory(decimal capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Value cannot be negative");
            Capacity = capacity;
        }

        public IGlass CreateGlass(uint row, uint index, decimal poured)
        {
            if (poured < 0) throw new ArgumentOutOfRangeException(nameof(poured), poured, "Value cannot be negative");
            
            if (index > row) throw new ArgumentOutOfRangeException(nameof(index), index, $"Row {row} only has {row + 1} glasses");
            if (GlassAllocations.Contains((row, index))) throw new InvalidOperationException($"Cannot create the same glass twice (row {row} index {index})");

            var glass = new Glass(row, index, poured, Capacity);
            GlassAllocations.Add((row, index));

            return glass;
        }
    }
}