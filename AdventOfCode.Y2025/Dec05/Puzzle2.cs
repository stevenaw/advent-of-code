using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Y2025.Dec05
{
    internal class Puzzle2 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var ranges = new List<(long min, long max)>();

            var enumerator = lines.GetEnumerator();
            while (enumerator.MoveNext() && !string.IsNullOrEmpty(enumerator.Current))
            {
                var line = enumerator.Current.AsSpan();
                var delim = line.IndexOf('-');

                var min = long.Parse(line.Slice(0, delim));
                var max = long.Parse(line.Slice(delim + 1));

                ranges.Add((min, max));
            }

            NormalizeRanges(ranges);

            long count = 0;
            foreach (var (min, max) in ranges)
            {
                count += max - min + 1; ;
            }

            return count;
        }
        private static void NormalizeRanges(List<(long min, long max)> ranges)
        {
            if (ranges is null || ranges.Count <= 1)
            {
                return;
            }

            // Sort by lower bound
            ranges.Sort((a, b) => a.min.CompareTo(b.min));

            var merged = new (long min, long max)[ranges.Count];
            var mergedCount = 0;
            foreach (var range in ranges)
            {
                if (mergedCount == 0)
                {
                    merged[mergedCount++] = range;
                    continue;
                }

                ref var last = ref merged[mergedCount-1];

                // If overlapping (next.min <= last.max) merge them.
                if (range.min <= last.max)
                {
                    last.max = Math.Max(last.max, range.max);
                }
                else
                {
                    merged[mergedCount++] = range;
                }
            }

            // Replace original list contents with merged results
            ranges.Clear();
            ranges.AddRange(merged.AsSpan(0, mergedCount));
        }
    }
}
