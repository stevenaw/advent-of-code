namespace AdventOfCode.Y2025.Dec02
{
    internal class Puzzle2 : AdventPuzzle
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

                    for (var i = start; i <= end; i++)
                    {
                        if (IsInvalid(i))
                        {
                            sum += i;
                        }
                    }
                }
            }

            return sum;

            static bool IsInvalid(long num)
            {
                var value = num.ToString().AsSpan();
                var digits = (int)(Math.Floor(Math.Log10(num)) + 1);

                var factors = GetFactors(digits).GetEnumerator<int>();
                if (!factors!.MoveNext())
                {
                    return false; 
                }

                do
                {
                    var len = factors.Current;
                    var needle = value.Slice(0, len);
                    var isMatch = true;

                    // Look for repeating segments
                    for (var offset = len; offset < digits; offset += len)
                    {
                        var segment = value.Slice(offset, len);
                        if (!segment.SequenceEqual(needle))
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                    {
                        return true;
                    }

                } while (factors.MoveNext());

                return false;
            }

            // A shortcut instead of dynamically calculating them
            // The compiled jump table will perform better than a
            // dynamic lookup.
            static int[] GetFactors(int n)
            {
                switch (n)
                {
                    case 0: return [];
                    case 1: return [];
                    case 2: return [1];
                    case 3: return [1];
                    case 4: return [1, 2];
                    case 5: return [1];
                    case 6: return [1, 2, 3];
                    case 7: return [1];
                    case 8: return [1, 2, 4];
                    case 9: return [1, 3];
                    case 10: return [1, 2, 5];
                    case 11: return [1];
                    case 12: return [1, 2, 3, 4, 6];
                    default: throw new NotImplementedException();
                }
            }
        }
    }
}
