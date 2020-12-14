using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Dec14
{
    class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var enumerator = lines.GetEnumerator();
            var memory = new Dictionary<int, ulong>();

            enumerator.MoveNext();
            while (TryParse(ref enumerator, out var initialization))
            {
                foreach(var assignment in initialization.Assignments)
                {
                    var newValue = (assignment.Value & ~initialization.Mask) | initialization.MaskOverrides;
                    memory[assignment.Address] = newValue;
                }
            }

            var overrideSum = 0UL;
            foreach (var kvp in memory)
                overrideSum += kvp.Value;

            return (long)overrideSum;
        }

        private static bool TryParse(ref IEnumerator<string> enumerator, out Initialization result)
        {
            ulong mask = 0L;
            ulong maskOverrides = 0L;
            var maskLine = enumerator.Current;

            if (string.IsNullOrEmpty(maskLine) || !maskLine.StartsWith("mask"))
            {
                result = null;
                return false;
            }

            var idx = 0;
            for(var i = maskLine.Length - 1; i >= 0 && maskLine[i] != ' '; i--)
            {
                if (maskLine[i] != 'X')
                    mask |= 1UL << idx;

                if (maskLine[i] == '1')
                    maskOverrides |= 1UL << idx;

                idx++;
            }

            var assignments = new List<(int Address, ulong Value)>();
            while (enumerator.MoveNext() && enumerator.Current.StartsWith("mem"))
            {
                var line = enumerator.Current.AsSpan();

                line = line.Slice(4);

                var addressIdx = line.IndexOf(']');
                var addressSpan = line.Slice(0, addressIdx);
                if (!Int32.TryParse(addressSpan, out var address))
                    address = 0;

                var valueIdx = line.LastIndexOf(' ');
                var valueSpan = line.Slice(valueIdx);
                if (!UInt64.TryParse(valueSpan, out var value))
                    value = 0;

                assignments.Add((address, value));
            }

            result = new Initialization
            {
                Mask = mask,
                MaskOverrides = maskOverrides,
                Assignments = assignments
            };
            return true;
        }
    }

    class Initialization
    {
        public ulong Mask { get; set; }
        public ulong MaskOverrides { get; set; }
        public List<(int Address, ulong Value)> Assignments { get; set; }
    }
}
