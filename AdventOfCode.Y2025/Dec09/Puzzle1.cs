using AdventOfCode.Y2025.Dec08;

namespace AdventOfCode.Y2025.Dec09
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var coords = lines.Select(Point.Parse).ToArray();

            coords.Sort((a, b) => a.X - b.X);

            var maxArea = 0L;

            foreach (var (a, b) in GetPairs(coords))
            {
                long width = (b.X - a.X) + 1;
                long height = Math.Abs(b.Y - a.Y) + 1;

                maxArea = Math.Max(maxArea, width * height);
            }

            return maxArea;
        }

        private static (Point a, Point b)[] GetPairs(Point[] coords)
        {
            var n = coords.Length;

            var result = GC.AllocateUninitializedArray<(Point, Point)>(n * (n / 2) - n / 2);
            var count = 0;

            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    result[count++] = new(coords[i], coords[j]);
                }
            }

            return result;
        }
    }
}
