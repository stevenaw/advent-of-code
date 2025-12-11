using System;

namespace AdventOfCode.Y2015.Dec20
{
    internal partial class Puzzle1 : AdventPuzzle
    {
        protected override long Solve(IEnumerable<string> lines)
        {
            var target = long.Parse(lines.First());

            for (var i = 1; i < target / 10; i++)
            {
                var gifts = FactorizationHelpers.GetFactors(i).Select(x => x * 10).Sum();
                if (gifts >= target)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
