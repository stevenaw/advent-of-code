using System.Runtime.CompilerServices;

namespace AdventOfCode.Y2018.Dec02
{
    internal class Puzzle2 : AdventPuzzle<string>
    {
        [SkipLocalsInit]
        protected override string Solve(IEnumerable<string> lines)
        {
            var data = lines.ToArray();

            for (var i = 0; i < data.Length; i++)
            {
                for (var j = i + 1; j < data.Length; j++)
                {
                    if (GetHammingDistance(data[i], data[j]) == 1)
                    {
                        return string.Create(data[i].Length - 1, (data[i], data[j]), static (span, state) =>
                        {
                            var (a, b) = state;
                            var index = 0;
                            for (var k = 0; k < a.Length; k++)
                            {
                                if (a[k] == b[k])
                                {
                                    span[index++] = a[k];
                                }
                            }
                        });
                    }
                }
            }

            return null;
        }

        private static int GetHammingDistance(ReadOnlySpan<char> a, ReadOnlySpan<char> b)
        {
            var distance = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    distance++;
                }
            }
            return distance;
        }
    }
}
