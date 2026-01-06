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

            var merged = new List<(long min, long max)>(ranges.Count);
            foreach (var range in ranges)
            {
                if (merged.Count == 0)
                {
                    merged.Add(range);
                    continue;
                }

                var last = merged[merged.Count - 1];

                // If overlapping (next.min <= last.max) merge them.
                if (range.min <= last.max)
                {
                    var newMax = Math.Max(last.max, range.max);
                    merged[merged.Count - 1] = (last.min, newMax);
                }
                else
                {
                    merged.Add(range);
                }
            }

            // Replace original list contents with merged results
            ranges.Clear();
            ranges.AddRange(merged);
        }
    }
}
