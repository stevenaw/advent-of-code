namespace AdventOfCode.Y2025.Dec02
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var sum = 0L;

            foreach (var line in lines)
            {
                var lineSpan = line.AsSpan();

                foreach (var split in lineSpan.Split(','))
                {
                    var segment = lineSpan[split];

                    if (segment.IsEmpty)
                    {
                        continue;
                    }

                    var idx = segment.IndexOf('-');
                    var start = long.Parse(segment.Slice(0, idx));
                    var end = long.Parse(segment.Slice(idx + 1));

                    var startDigits = (int)(Math.Floor(Math.Log10(start)) + 1);
                    var endDigits = (int)(Math.Floor(Math.Log10(end)) + 1);

                    if (startDigits == endDigits && startDigits % 2 != 0)
                    {
                        // Start and end are both same number of digits
                        // and also both odd number of digits.
                        // So no valid numbers in this range.
                        continue;
                    }

                    for (var i = start; i <= end; i++)
                    {
                        var value = i.ToString();
                        if (value.Length % 2 != 0)
                        {
                            continue;
                        }

                        var firstHalf = value.AsSpan(0, value.Length / 2);
                        var secondHalf = value.AsSpan(value.Length / 2);

                        if (firstHalf.SequenceEqual(secondHalf))
                        {
                            sum += i;
                        }
                    }
                }
            }

            return sum;
        }
    }
}
