using System.Text.RegularExpressions;

namespace AdventOfCode.Y2017.Dec04
{
    internal class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var validCount = 0L;

            foreach(var line in lines)
            {
                var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var distinctCount = tokens.Distinct(StringComparer.OrdinalIgnoreCase).Count();

                if (distinctCount == tokens.Length)
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}
