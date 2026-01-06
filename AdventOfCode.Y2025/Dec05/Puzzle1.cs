namespace AdventOfCode.Y2025.Dec05
{
    internal class Puzzle1 : AdventPuzzle
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
                var max = long.Parse(line.Slice(delim+1));

                ranges.Add((min, max));
            }

            var count = 0;
            while (enumerator.MoveNext())
            {
                var id = long.Parse(enumerator.Current.AsSpan());
                if (ranges.Any(r => r.min <=  id && r.max >= id))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
